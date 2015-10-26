﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace UBSFundManager.Infrastructure.Utility
{
  
    public class TextBoxInputBehavior : Behavior<TextBox>
    {
        const NumberStyles validNumberStyles = NumberStyles.AllowDecimalPoint |NumberStyles.Number|NumberStyles.Integer|NumberStyles.Currency|NumberStyles.Float|
                                                   NumberStyles.AllowThousands |   NumberStyles.AllowLeadingSign;
        public TextBoxInputBehavior()
        {
            this.InputMode = TextBoxInputMode.None;
            this.JustPositivDecimalInput = false;
        }

        public TextBoxInputMode InputMode { get; set; }


        public static readonly DependencyProperty JustPositivDecimalInputProperty =
         DependencyProperty.Register("JustPositivDecimalInput", typeof(bool),
         typeof(TextBoxInputBehavior), new FrameworkPropertyMetadata(false));

        public bool JustPositivDecimalInput
        {
            get { return (bool)GetValue(JustPositivDecimalInputProperty); }
            set { SetValue(JustPositivDecimalInputProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
           
            AssociatedObject.PreviewTextInput += AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown += AssociatedObjectPreviewKeyDown;

            DataObject.AddPastingHandler(AssociatedObject, Pasting);

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown -= AssociatedObjectPreviewKeyDown;

            DataObject.RemovePastingHandler(AssociatedObject, Pasting);
        }

        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));

                if (!this.IsValidInput(this.GetText(pastedText)))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.CancelCommand();
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                e.CancelCommand();
            }
        }

        private void AssociatedObjectPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (!this.IsValidInput(this.GetText(" ")))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }
            }
        }

        private void AssociatedObjectPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!this.IsValidInput(this.GetText(e.Text)))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private string GetText(string input)
        {
            var txt = this.AssociatedObject;
            var realtext = txt.Text.Remove(txt.SelectionStart, txt.SelectionLength);
            var newtext = realtext.Insert(txt.CaretIndex, input);

            return newtext;
        }

        private bool IsValidInput(string input)
        {
            switch (InputMode)
            {
                case TextBoxInputMode.None:
                    return true;
                case TextBoxInputMode.DigitInput:
                    return CheckIsDigit(input);

                case TextBoxInputMode.DecimalInput:
                    decimal d;

                                      
                    //if (input.Trim().ToCharArray().Where(x => x == ',').Count() > 1)
                    //    return false;

                    if (input.Contains("-"))
                    {
                        
                        if (!this.JustPositivDecimalInput && input.IndexOf("-") == 0 && input.Length == 1)
                            return true;
                        else
                        {
                            var result = decimal.TryParse(input.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out d);
                            return result;
                        }
                    }
                    else
                    {
                        var result = decimal.TryParse(input.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out d);
                        return result;
                    }


                default: throw new ArgumentException("Unknown TextBoxInputMode");

            }
            return true;
        }

        private bool CheckIsDigit(string val)
        {
            try
            {
                const NumberStyles validDigitNumberStyles = NumberStyles.Integer|NumberStyles.Number|
                                                  NumberStyles.AllowThousands |
                                                  NumberStyles.AllowLeadingSign;
                int intval = 0;
                var result = int.TryParse(val,validDigitNumberStyles,CultureInfo.CurrentCulture, out intval);
                return result;
            }
            catch
            {
                return false;
            }
        }
    }

    public enum TextBoxInputMode
    {
        None,
        DecimalInput,
        DigitInput
    }
}
