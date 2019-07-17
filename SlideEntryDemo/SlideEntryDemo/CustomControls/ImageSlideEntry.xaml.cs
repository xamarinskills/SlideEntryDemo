using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SlideEntryDemo.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageSlideEntry : ContentView
	{
        public ImageSlideEntry()
        {
            InitializeComponent();
            MainEntry.BindingContext = this;
            MainEntry.Focused += async (s, a) =>
            {
                if (string.IsNullOrEmpty(MainEntry.Text))
                {
                    MainImg2.WidthRequest = MainImg2.HeightRequest = 24;
                    await Task.WhenAll(
                        MainEntry.TranslateTo(MainEntry.TranslationX - 28, 0, 200, Easing.BounceIn),
                        MainImg1.ScaleTo(0, 120),
                        MainImg1.FadeTo(0, 100),
                        MainImg2.ScaleTo(1, 120),
                        MainImg2.FadeTo(1, 100)
                     );
                }
            };
            MainEntry.Unfocused += async (s, a) =>
            {
                if (string.IsNullOrEmpty(MainEntry.Text))
                {
                    await Task.WhenAll(
                            MainImg2.ScaleTo(0, 120),
                            MainImg2.FadeTo(0, 100),
                            MainImg1.FadeTo(1, 100),
                            MainImg1.ScaleTo(1, 120),
                       MainEntry.TranslateTo(MainEntry.TranslationX + 28, 0, 200, Easing.BounceIn)
                     );
                }
            };
        }

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(ImageSlideEntry),
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                          propertyChanged: (bindable, oldVal, newVal) =>
                                                          {
                                                              var matEntry = (ImageSlideEntry)bindable;
                                                              matEntry.MainImg1.Source = (ImageSource)newVal;
                                                              matEntry.MainImg2.Source = (ImageSource)newVal;
                                                          });

        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
            typeof(string),
            typeof(ImageSlideEntry),
            defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
            typeof(string),
            typeof(ImageSlideEntry),
            defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool),
            typeof(ImageSlideEntry), defaultValue: false);

        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(ImageSlideEntry), defaultValue: Keyboard.Default);

        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(ImageSlideEntry), defaultValue: Color.Accent);
        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ImageSlideEntry), defaultValue: Color.Accent);

        public static BindableProperty StartColorProperty = BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(ImageSlideEntry), defaultValue: Color.Accent);
        public static BindableProperty EndColorProperty = BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(ImageSlideEntry), defaultValue: Color.Accent);

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
    }
}