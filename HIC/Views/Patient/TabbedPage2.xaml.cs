using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIC.Views.Patient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage2 : TabbedPage
    {
        public TabbedPage2()
        {
            InitializeComponent();
            
            History.IconImageSource = ImageSource.FromResource("HIC.Common.time-history.png", typeof(TabbedPage2).GetTypeInfo().Assembly);
            Profile.IconImageSource = ImageSource.FromResource("HIC.Common.user.png", typeof(TabbedPage2).GetTypeInfo().Assembly);
        }
    }
}