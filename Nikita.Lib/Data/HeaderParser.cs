using System;
using System.IO;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Data
{
    public class HeaderParser : IParser<DataMeta>
    {
        public  DataMeta Parse(string data)
        {
            DataMeta meta = new DataMeta();
            try
            {  
                meta.Delimiter = GetDelimiter(data);

                var header = data.Split(meta.Delimiter);

                for (int i = 0; i < header.Length; i++)
                {   
                    meta.Fields.Add(header[i].Trim().ToLower(), i );
                }
            }
            catch (Exception e)
            {
                meta.Error = new DataError() {Exception = e, RawData = data};
            }
            return meta;
        }

        private char GetDelimiter(string data)
        {
            if (data.Split(',').Length == 5)
                return ',';
            if (data.Split(' ').Length == 5)
                return ' ';
            if (data.Split('|').Length == 5)
                return '|';

            throw new InvalidDataException("Invalid header.");
        }
    }
}
