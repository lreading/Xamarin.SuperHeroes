using System.Collections.ObjectModel;
using Xamarin.SuperHeroes.Models;

namespace Xamarin.SuperHeroes.ViewModels
{
    public class SuperHeroesViewModel
    {
        public ObservableCollection<SuperHeroModel> SuperHeroes { get; set; }

        public SuperHeroesViewModel()
        {
            SuperHeroes = new ObservableCollection<SuperHeroModel>
            {
                new SuperHeroModel
                {
                    Name = "Super Bald Man",
                    Biography = "Super Bald Man blinds his enemies with the ultra reflective properties of the skin on top of his head.",
                    Blurb = "The name says it all - AKA Leo Reading",
                    YearOfFirstAppearance = 1989,
                    ImageURL = "http://www.leoreading.com/assets/theme/img/LeoReading3.jpg"
                }
            };
        } // end constructor
    } // end class super heros view model
} // end namespace