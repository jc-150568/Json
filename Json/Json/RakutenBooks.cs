using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Json
{
    /*
    [DataContract]
    public class RakutenBooks
    {
        [DataMember]
        public int count { get; set; }
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public string first { get; set; }
        [DataMember]
        public int last { get; set; }
        [DataMember]
        public int hits { get; set; }
        [DataMember]
        public int carrier { get; set; }
        [DataMember]
        public int pageCount { get; set; }

        [DataMember]
        public List<Item> Items { get; set; }

        [DataContract]
        public class Item
        {
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string titleKana { get; set; }
            [DataMember]
            public string subTitle { get; set; }
            [DataMember]
            public string subTitleKana { get; set; }
            [DataMember]
            public string seriesName { get; set; }
            [DataMember]
            public string seriesNameKana { get; set; }
            [DataMember]
            public string contents { get; set; }
            [DataMember]
            public string author { get; set; }
            [DataMember]
            public string authorKana { get; set; }
            [DataMember]
            public string publisherName { get; set; }
            [DataMember]
            public int size { get; set; }
            [DataMember]
            public string isbn { get; set; }
            [DataMember]
            public string itemCaption { get; set; }
            [DataMember]
            public string salesDate { get; set; }
            [DataMember]
            public int itemPrice { get; set; }
            [DataMember]
            public int listPrice { get; set; }
            [DataMember]
            public float discountRate { get; set; }
            [DataMember]
            public int discountPrice { get; set; }
            [DataMember]
            public string itemUrl { get; set; }
            [DataMember]
            public string affiliateUrl { get; set; }
            [DataMember]
            public string smallImageUrl { get; set; }
            [DataMember]
            public string mediumImageUrl { get; set; }
            [DataMember]
            public string largeImageUrl { get; set; }
            [DataMember]
            public string chirayomiUrl { get; set; }
            [DataMember]
            public int availability { get; set; }
            [DataMember]
            public int postageFlag { get; set; }
            [DataMember]
            public int limitedFlag { get; set; }
            [DataMember]
            public float reviewcount { get; set; }
            [DataMember]
            public float reviewAverage { get; set; }
            [DataMember]
            public string booksGenreId { get; set; }
        }
    }
    */
    //[JsonConverter(typeof())]
    public class RakutenBooks
    {
        
        public int count { get; set; }
        
        public int page { get; set; }
        
        public string first { get; set; }
        
        public int last { get; set; }
        
        public int hits { get; set; }
        
        public int carrier { get; set; }
        
        public int pageCount { get; set; }

        
        public List<Item> Items { get; set; }


        public class Item
        {

            public string title { get; set; }
            
            public string titleKana { get; set; }
            
            public string subTitle { get; set; }
            
            public string subTitleKana { get; set; }
            
            public string seriesName { get; set; }
            
            public string seriesNameKana { get; set; }
            
            public string contents { get; set; }
            
            public string author { get; set; }
            
            public string authorKana { get; set; }
            
            public string publisherName { get; set; }
            
            public int size { get; set; }
            
            public string isbn { get; set; }
            
            public string itemCaption { get; set; }
            
            public string salesDate { get; set; }
            
            public int itemPrice { get; set; }
            
            public int listPrice { get; set; }
            
            public float discountRate { get; set; }
            
            public int discountPrice { get; set; }
            
            public string itemUrl { get; set; }
            
            public string affiliateUrl { get; set; }
            
            public string smallImageUrl { get; set; }
            
            public string mediumImageUrl { get; set; }
            
            public string largeImageUrl { get; set; }
            
            public string chirayomiUrl { get; set; }
            
            public int availability { get; set; }
            
            public int postageFlag { get; set; }
            
            public int limitedFlag { get; set; }
            
            public float reviewcount { get; set; }
            
            public float reviewAverage { get; set; }
            
            public string booksGenreId { get; set; }
        }

        /*
        public class ItemsConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => objectType == typeof(List<Item>);

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return serializer.Deserialize<JObject>(reader).Properties().Select(p =>

                {

                    var Item = p.Value.ToObject<Item>();

                    Item.title = p.;

                    return Item;

                }).ToList();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        */
    }
}
