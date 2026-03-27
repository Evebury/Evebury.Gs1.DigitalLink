using Evebury.Gs1.DigitalLink.Segments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Resolve a GS1 DigitalLink payload to strongly typed values
    /// </summary>
    public class DigitalLinkResolver
    {
        /// <summary>
        /// Resolves a GS1 DigitalLink payload to strongly typed values
        /// </summary>
        /// <param name="uri">the digital link payload uri</param>
        /// <returns></returns>
        public static DigitalLink Resolve(string uri)
        {

            Regex regex = DigitalLinkBuilder.DigitalLinkRegex();
            if (!regex.IsMatch(uri))
            {
                DigitalLink link = new();
                link.SetErrors([new($"Invalid digital link format '{uri}'.")]);
                return link;
            }

            char[] chars = uri.ToCharArray();
            int length = chars.Length;
            int index = 0;
            //skip domain and foward to first forward slash
            StringBuilder sb = new();
            while (index < length)
            {
                char @char = chars[index];
                //skip https://x, will work for http://xx also: length = 8
                if (@char == '/' && index > 8)
                {
                    break;
                }
                sb.Append(@char);
                index++;
            }

            bool digits = true;
            int peek = index + 1;
            int offset = 0;
            while (peek < length)
            {
                char @char = chars[peek];
                if (@char == '/')
                {
                    if (digits)
                    {
                        //first primary identifier found
                        //this is conform GS1 documentation if all digits identifiers start is assumed
                        break;
                    }
                    else
                    {
                        //domain folder path
                        digits = true;
                        offset = peek;
                    }

                }
                else 
                {
                    digits = digits && char.IsDigit(@char);
                   
                }
                peek++;
            }
            for (; index < offset; index++) 
            {
                sb.Append(chars[index]);
            }

            string domain = sb.ToString();

            List<DigitalLinkSegment> segments = [];
            while (index < length)
            {
                DigitalLinkSegment segment = GetSegment(chars, ref index, length);
                if (segment.IsInvalid)
                {
                    DigitalLink link = new();
                    link.SetErrors([new($"Invalid segment found in '{uri}'.")]);
                    return link;
                }

                string segmentType = Segments.MetaData.Resource.SegmentType.ResourceManager.GetString(segment.Code);
                if (string.IsNullOrEmpty(segmentType)) 
                {
                    DigitalLink link = new();
                    link.SetErrors([new($"No segment type defined for '{segment.Code}'.")]);
                    return link;
                }

                segment.Type = (SegmentType)int.Parse(segmentType);
                string valueType = Segments.MetaData.Resource.ValueType.ResourceManager.GetString(segmentType);
                if (!string.IsNullOrEmpty(valueType)) 
                {
                    segment.ValueType = (SegmentValueType)int.Parse(valueType);
                }
                segments.Add(segment);
            }

            DigitalLinkSegment primary = segments[0];
            PrimaryKeyType type = (PrimaryKeyType)int.Parse(primary.Code);
            DigitalLinkBuilder builder = new();
            builder.SetPrimaryKey(type, primary.Value);
            builder.SetCustomDomainUri(domain);
            segments.RemoveAt(0);
            
            builder.ParseSegments(segments);
            
            return builder.Build();
        }

        private static DigitalLinkSegment GetSegment(char[] uri, ref int index, int length)
        {
            char @char = uri[index];
            if (@char == '?')
            {
                index++;
            }

            //call after ? first param after ? may start with &
            if (@char == '&' || @char == '/')
            {
                index++;
            }

            string code = GetPart(uri, ref index, length);
            string value = null;

            @char = uri[index];
            if (@char == '/' || @char == '=')
            {
                index++;
                value = GetPart(uri, ref index, length);
                if (value != null)
                {
                    value = HttpUtility.UrlDecode(value);
                }
            }

            return new DigitalLinkSegment(code, value);
        }

        private static string GetPart(char[] uri, ref int index, int length)
        {
            StringBuilder sb = new();
            while (index < length)
            {
                char @char = uri[index];

                if (@char == '?' || @char == '/' || @char == '=' || @char == '&')
                {
                    break;
                }

                sb.Append(@char);
                index++;
            }

            string part = sb.ToString();
            if (part == string.Empty) return null;
            return part;
        }
    }
}
