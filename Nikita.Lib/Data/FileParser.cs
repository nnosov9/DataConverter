 
using System;
using System.IO;
using System.Text;
using Nikita.Lib.Interfaces;

namespace Nikita.Lib.Data
{
    public class DataFileParser<T> : IParser<IDataFile<T>>
    {
        private IParser<DataMeta> _headerParser;
        private IRecordParser<T> _recordParser;

        public DataFileParser(IParser  headerParser, IParser recordParser)
        {
            _headerParser = headerParser as IParser<DataMeta>;
            _recordParser = recordParser as IRecordParser<T>;

        }

        public IDataFile<T> Parse(string filePath)
        {
            DataFile<T> df = new DataFile<T>();
            if (File.Exists(filePath))
            {
                StreamReader reader = File.OpenText(filePath);
               
                df.Meta = _headerParser.Parse(reader.ReadLine());     

                if (df.Meta.Error == null)
                {


                    while (!reader.EndOfStream)
                    {
                        var raw = reader.ReadLine();
                        try
                        {
                            var person = _recordParser.Parse(raw, df.Meta);
                            df.Items.Add(person);
                        }
                        catch (Exception e)
                        {
                            df.Errors.Add(new DataError() {Exception = e, RawData = raw});
                        }
                    }
                }
            }
            else
            {
                df.Errors.Add(new DataError() {Exception = new IOException("Missing file or incorrect filePath"),RawData = filePath});
            }
            return df;
        }
    }

}
