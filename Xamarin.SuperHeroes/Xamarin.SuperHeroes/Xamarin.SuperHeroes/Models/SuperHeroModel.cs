namespace Xamarin.SuperHeroes.Models
{
    public class SuperHeroModel
    {
        public string Name { get; set; }                    // The SuperHero Name
        public string Blurb { get; set; }                   // A brief description
        public int YearOfFirstAppearance { get; set; }      // The year the super hero made their first appearance
        public string ImageURL { get; set; }                // A URL to some image of the super hero
        public string Biography { get; set; }               // An extended biography
    } // end class super hero model
} // end namespace