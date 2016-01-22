using Xamarin.Forms;
using Xamarin.SuperHeroes.Models;

namespace Xamarin.SuperHeroes.Views
{
    public class SuperHeroesDetailsPage : ContentPage
    {
        public SuperHeroesDetailsPage(SuperHeroModel hero)
        {
            // Create a scroll view.  On most devices, the biography will be too large for the viewport
            var scroll = new ScrollView
            {
                Padding = 20
            };

            // Create a stack layout to put in the scroll view
            var stack = new StackLayout();

            // Name
            var title = new Label
            {
                Text = hero.Name,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                XAlign = TextAlignment.Center
            };

            // Blurb
            var blurb = new Label
            {
                Text = hero.Blurb,
                FontAttributes = FontAttributes.Italic,
                XAlign = TextAlignment.Center
            };

            // Year of first appearance
            var year = new Label
            {
                Text = string.Format("Year of first appearance: {0}", hero.YearOfFirstAppearance.ToString()),
                FontAttributes = FontAttributes.Italic,
                XAlign = TextAlignment.Center
            };

            // SuperHero image - Source property will load the image async!
            var img = new Image
            {
                Source = hero.ImageURL
            };

            // Biography
            var bio = new Label
            {
                Text = hero.Biography
            };

            // Build the stack layout
            stack.Children.Add(title);
            stack.Children.Add(blurb);
            stack.Children.Add(year);
            stack.Children.Add(img);
            stack.Children.Add(bio);

            // Set the content of the scroll view
            scroll.Content = stack;

            // Set the title and content of the page
            this.Title = hero.Name;
            this.Content = scroll;
        } // end constructor
    } // end super heroes details page
} // end namespace