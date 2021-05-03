using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhysioCam.Resources.Templates
{
    public class ButtonControlTemplate : ContentView
    {
        public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(ButtonControlTemplate),
                Color.White);

        public Color ButtonBackgroundColor
        {
            get => (Color) GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }
        
        
        
        public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(ButtonControlTemplate),
                string.Empty);

        public string ButtonText
        {
            get => (string) GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }
        
        
        
        public static readonly BindableProperty ButtonTextColorProperty =
            BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(ButtonControlTemplate));

        public Color ButtonTextColor
        {
            get => (Color) GetValue(ButtonTextColorProperty);
            set => SetValue(ButtonTextColorProperty, value);
        }
        
        
        
        public static readonly BindableProperty ButtonIconProperty =
            BindableProperty.Create(nameof(ButtonIcon), typeof(ImageSource), typeof(ButtonControlTemplate));

        public ImageSource ButtonIcon
        {
            get => (ImageSource) GetValue(ButtonIconProperty);
            set => SetValue(ButtonIconProperty, value);
        }
        
        
        
        public static readonly BindableProperty ButtonClickedProperty =
            BindableProperty.Create(nameof(ButtonClicked), typeof(ICommand), typeof(ButtonControlTemplate));

        public ICommand ButtonClicked
        {
            get => (ICommand) GetValue(ButtonClickedProperty);
            set => SetValue(ButtonClickedProperty, value);
        }
        
        
        
        public static readonly BindableProperty ButtonClickedParamProperty =
            BindableProperty.Create(nameof(ButtonClickedParam), typeof(object), typeof(ButtonControlTemplate));

        public object ButtonClickedParam
        {
            get => GetValue(ButtonClickedParamProperty);
            set => SetValue(ButtonClickedParamProperty, value);
        }
    }
}