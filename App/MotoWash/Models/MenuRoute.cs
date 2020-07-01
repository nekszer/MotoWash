using MotoWash.Controls;

namespace MotoWash.Models
{
    public class MenuRoute : ModelBase
    {
        public string Title { get; set; }
        public Glyph Glyph { get; set; }
        public string Route { get; internal set; }
    }
}