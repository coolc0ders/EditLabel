using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EditableLabel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditableLabel : ContentView
	{
        public static readonly BindableProperty IsFocusedModeProperty = BindableProperty.Create("IsFocusedMode", typeof(bool), typeof(EditableLabel), default(bool), propertyChanged: OnIsFocusedModePropertyChanged);
        public bool IsFocusedMode
        {
            get { return (bool)GetValue(IsFocusedModeProperty); }
            set { SetValue(IsFocusedModeProperty, value); }
        }

        private async static void OnIsFocusedModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)(newValue) == true)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(100);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        (bindable as EditableLabel).MainEntry.Focus();
                        (bindable as EditableLabel).MainEntry.CursorPosition = (bindable as EditableLabel).MainEntry.Text?.Length ?? 0;
                    });
                });
            }
        }

        public static readonly BindableProperty ContentChangedProperty = BindableProperty.Create("ContentChanged", typeof(bool), typeof(EditableLabel), default(bool), propertyChanged : OnContentChangedPropertyChanged);
        public bool ContentChanged
        {
            get { return (bool)GetValue(ContentChangedProperty); }
            private set { SetValue(ContentChangedProperty, value); }
        }

        private async static void OnContentChangedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((Boolean)(newValue) == true)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(100);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        (bindable as EditableLabel).MainEntry.Focus();
                        (bindable as EditableLabel).MainEntry.CursorPosition = (bindable as EditableLabel).MainEntry.Text?.Length ?? 0;
                    });
                });
            }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(EditableLabel), default(string));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(float), typeof(EditableLabel), 12f);
        public float FontSize
        {
            get { return (float)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create("PlaceHolder", typeof(string), typeof(EditableLabel), default(string));
        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(EditableLabel), default(string));
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(EditableLabel), default(FontAttributes));
        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(EditableLabel), default(Color));
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        
        public EditableLabel ()
		{
			InitializeComponent ();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            IsFocusedMode = true;
        }
    }
}