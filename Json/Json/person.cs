using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Json
{
    public class person
    {
        [JsonProperty("name")] //プロパティ名とは別のキーを指定したい場合はJsonProperty属性を使用
        public string Name { get; set; }

        [JsonIgnore] //対象のプロパティにJsonIgnore属性を付与することでシリアライズの対象外にすることができます。
        public string country { get; set; }

        public int Age { get; set; }
    }
}
