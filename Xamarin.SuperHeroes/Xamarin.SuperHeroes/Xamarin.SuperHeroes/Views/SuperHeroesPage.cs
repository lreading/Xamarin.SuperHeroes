using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.SuperHeroes.BLL;
using Xamarin.SuperHeroes.Models;
using Xamarin.SuperHeroes.ViewModels;

namespace Xamarin.SuperHeroes.Views
{
    public class SuperHeroesPage : ContentPage
    {
        private SuperHeroesViewModel _vm;
        private ActivityIndicator _ai;

        public SuperHeroesPage()
        {
            // Create the objects
            _vm = new SuperHeroesViewModel();
            _ai = new ActivityIndicator();
            var lv = new ListView();
            var stack = new StackLayout();
            var btn = new Button
            {
                Text = "Load More SuperHeroes!"
            };
            var template = new DataTemplate(typeof(ImageCell));

            // Template Bindings
            template.SetBinding(ImageCell.TextProperty, "Name");
            template.SetBinding(ImageCell.DetailProperty, "Blurb");
            template.SetBinding(ImageCell.ImageSourceProperty, "ImageURL");

            // Activity Indicator Bindings - Bind to the IsBusy property of this page
            _ai.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");

            // List view item binding
            lv.ItemsSource = _vm.SuperHeroes;

            // Make the listview aware of the template/bindings
            lv.ItemTemplate = template;

            // Events
            lv.ItemTapped += Lv_ItemTapped;
            btn.Clicked += Btn_Clicked;

            // Construct the stack layout
            stack.Children.Add(lv);
            stack.Children.Add(btn);

            // Set the title and main content
            this.Title = "Super Heroes";
            this.Content = stack;
        } // end constructor

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            // By telling the page its busy, the binding on the activity indicator will force it to show
            this.IsBusy = true;
            var service = new SuperHeroService();

            // Get a list of the existing superhero names so we don't add duplicates.
            var existingHeroNames = _vm.SuperHeroes.Select(x => x.Name);

            // Get the list of superheroes from the web
            var heroes = await service.GetSuperHeroesAsync();

            // We do not need to invoke this on the UI thread, but if we did...
            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    // UI thread code here
            //});

            // Add the results to the observable collection
            foreach (var hero in heroes)
            {
                // Don't add duplicates
                if (!existingHeroNames.Contains(hero.Name))
                {
                    _vm.SuperHeroes.Add(hero);
                } // end if
            } // end loop

            // We are no longer busy, and the activity indicator can hide.
            this.IsBusy = false;
        } // end Btn_Clicked

        private void Lv_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // ItemTappedEventArgs has an Item propery.  This is the model we used in the list view's bindings for ItemsSource
            var hero = e.Item as SuperHeroModel;

            // Make sure it is not null, if so, do nothing
            if (hero == null)
            {
                return;
            }

            // Navigate to the details page
            Navigation.PushAsync(new SuperHeroesDetailsPage(hero));

            // Remove the selected indicator
            var lv = sender as ListView;
            lv.SelectedItem = null;
        } // end lv_ItemTapped
    } // end super heroes page
} // end namespace