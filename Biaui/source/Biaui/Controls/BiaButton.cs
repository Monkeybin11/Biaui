﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Biaui.Internals;

namespace Biaui.Controls
{
    public class BiaButton : FrameworkElement
    {
        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(BiaButton));

        #region Content

        public string Content
        {
            get => _content;
            set
            {
                if (value != _content)
                    SetValue(ContentProperty, value);
            }
        }

        private string _content;

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(nameof(Content), typeof(string), typeof(BiaButton),
                new FrameworkPropertyMetadata(
                    default(string),
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._content = (string) e.NewValue;
                        self.UpdateSize();
                    }));

        #endregion

        #region Command

        public ICommand Command
        {
            get => _Command;
            set
            {
                if (value != _Command)
                    SetValue(CommandProperty, value);
            }
        }

        private ICommand _Command;

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(BiaButton),
                new PropertyMetadata(
                    default(ICommand),
                    (s, e) =>
                    {
                        var self = (BiaButton) s;

                        if (self._Command != null)
                            self._Command.CanExecuteChanged -= self.CommandOnCanExecuteChanged;

                        self._Command = (ICommand) e.NewValue;

                        if (self._Command != null)
                            self._Command.CanExecuteChanged += self.CommandOnCanExecuteChanged;

                        self.CommandOnCanExecuteChanged(null, null);
                    }));

        private void CommandOnCanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
                IsEnabled = Command.CanExecute(CommandParameter);
        }

        #endregion

        #region CommandParameter

        public object CommandParameter
        {
            get => _CommandParameter;
            set
            {
                if (value != _CommandParameter)
                    SetValue(CommandParameterProperty, value);
            }
        }

        private object _CommandParameter;

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(BiaButton),
                new PropertyMetadata(
                    default,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._CommandParameter = e.NewValue;
                    }));

        #endregion

        #region Background

        public Brush Background
        {
            get => _Background;
            set
            {
                if (value != _Background)
                    SetValue(BackgroundProperty, value);
            }
        }

        private Brush _Background;

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(BiaButton),
                new FrameworkPropertyMetadata(
                    default(Brush),
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._Background = (Brush) e.NewValue;
                    }));

        #endregion

        #region Foreground

        public Brush Foreground
        {
            get => _Foreground;
            set
            {
                if (value != _Foreground)
                    SetValue(ForegroundProperty, value);
            }
        }

        private Brush _Foreground;

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(BiaButton),
                new FrameworkPropertyMetadata(
                    default(Brush),
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._Foreground = (Brush) e.NewValue;
                    }));

        #endregion

        #region CornerRadius

        public double CornerRadius
        {
            get => _CornerRadius;
            set
            {
                if (NumberHelper.AreClose(value, _CornerRadius) == false)
                    SetValue(CornerRadiusProperty, value);
            }
        }

        private double _CornerRadius;

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(double), typeof(BiaButton),
                new FrameworkPropertyMetadata(
                    Boxes.Double0,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._CornerRadius = (double) e.NewValue;
                    }));

        #endregion

        #region IsPressed

        public bool IsPressed
        {
            get => _IsPressed;
            set
            {
                if (value != _IsPressed)
                    SetValue(IsPressedProperty, Boxes.Bool(value));
            }
        }

        private bool _IsPressed;

        public static readonly DependencyProperty IsPressedProperty =
            DependencyProperty.Register(nameof(IsPressed), typeof(bool), typeof(BiaButton),
                new FrameworkPropertyMetadata(
                    Boxes.BoolFalse,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._IsPressed = (bool) e.NewValue;
                    }));

        #endregion

        #region IsPressedMouseOver

        public bool IsPressedMouseOver
        {
            get => _isPressedMouseOver;
            set
            {
                if (value != _isPressedMouseOver)
                    SetValue(IsPressedMouseOverProperty, Boxes.Bool(value));
            }
        }

        private bool _isPressedMouseOver;

        public static readonly DependencyProperty IsPressedMouseOverProperty =
            DependencyProperty.Register(nameof(IsPressedMouseOver), typeof(bool), typeof(BiaButton),
                new FrameworkPropertyMetadata(
                    Boxes.BoolFalse,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender,
                    (s, e) =>
                    {
                        var self = (BiaButton) s;
                        self._isPressedMouseOver = (bool) e.NewValue;
                    }));

        #endregion

        static BiaButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BiaButton),
                new FrameworkPropertyMetadata(typeof(BiaButton)));
        }

        protected override void OnRender(DrawingContext dc)
        {
            if (ActualWidth <= 1 ||
                ActualHeight <= 1)
                return;

            // 背景
            {
                if (NumberHelper.AreCloseZero(CornerRadius))
                    dc.DrawRectangle(
                        Background,
                        null,
                        this.RoundLayoutActualRectangle(false));
                else
                    dc.DrawRoundedRectangle(
                        Background,
                        null,
                        this.RoundLayoutActualRectangle(false),
                        CornerRadius,
                        CornerRadius);
            }

            // キャプション
            var y = 4; // todo:正しく求める

            TextRenderer.Default.Draw(Content, 0, y, Foreground, dc, ActualWidth, TextAlignment.Center);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            IsPressed = IsInMouse(e);

            CaptureMouse();

            e.Handled = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            IsPressedMouseOver = IsInMouse(e);

            e.Handled = true;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            if (IsPressed == false)
                return;

            if (IsMouseCaptured)
                ReleaseMouseCapture();

            IsPressed = false;

            if (IsInMouse(e) == false)
                return;

            Clicked();

            e.Handled = true;
        }

        private bool IsInMouse(MouseEventArgs e)
        {
            var pos = e.GetPosition(this);

            return
                pos.X >= 0.0 &&
                pos.X <= ActualWidth &&
                pos.Y >= 0.0 &&
                pos.Y <= ActualHeight;
        }

        protected virtual void Clicked()
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent, this));

            if (Command != null &&
                Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        private double _textWidth;

        protected override Size MeasureOverride(Size constraint)
        {
            var h = Height;
            if (double.IsNaN(h))
                h = Constants.BasicOneLineHeight;
            else if (double.IsInfinity(h))
                h = Constants.BasicOneLineHeight;

            return new Size((_textWidth, constraint.Width).Min(), h);
        }

        private void UpdateSize()
        {
            var w = TextRenderer.Default.CalcWidth(Content);

            _textWidth = Constants.ButtonPaddingX + w + Constants.ButtonPaddingX;
        }
    }
}