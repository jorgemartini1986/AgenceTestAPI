using System.Collections.Generic;

namespace AgenceIntro.Domain.Dto
{
    public class CollectionResponse<T>
    {
        public CollectionResponse()
        {
            Items = new List<T>();
        }

        public int SourceTotal { get; set; }

        public List<T> Items { get; }
    }
}
