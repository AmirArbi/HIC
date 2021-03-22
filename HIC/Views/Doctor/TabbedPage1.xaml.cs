using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIC.Views.Doctor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            History.IconImageSource = ImageSource.FromResource("HIC.Common.time-history.png", typeof(TabbedPage1).GetTypeInfo().Assembly);
            Scan.IconImageSource = ImageSource.FromResource("HIC.Common.camera.png", typeof(TabbedPage1).GetTypeInfo().Assembly);
            Profile.IconImageSource = ImageSource.FromResource("HIC.Common.user.png", typeof(TabbedPage1).GetTypeInfo().Assembly);


        }
    }
}