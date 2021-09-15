using AfterworldQuestManager.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AfterworldQuestManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}