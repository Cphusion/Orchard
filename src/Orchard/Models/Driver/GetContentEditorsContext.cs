using System.Collections.Generic;
using Orchard.UI.Models;

namespace Orchard.Models.Driver {
    public class GetContentEditorsContext {
        public GetContentEditorsContext(ContentItem part) {
            ContentItem = part;
            Editors= new List<ModelTemplate>();
        }
        public ContentItem ContentItem { get; set; }
        public IList<ModelTemplate> Editors { get; set; }
    }
}