﻿using System;
using System.Windows;
using System.Windows.Media.Effects;
using Biaui.Internals;

namespace Biaui.Controls.Effects
{
    internal class HsvBoxBackgroundEffect : ShaderEffect
    {
        public HsvBoxBackgroundEffect()
        {
            var ps = new PixelShader
            {
                UriSource = new Uri("pack://application:,,,/Biaui;component/Controls/Effects/HsvBoxBackgroundEffect.ps")
            };

            ps.Freeze();

            PixelShader = ps;
            UpdateShaderValue(ValueProperty);
        }

        #region Value

        public double Value
        {
            get => _Value;
            set
            {
                if (NumberHelper.AreClose(value, Value) == false)
                    SetValue(ValueProperty, value);
            }
        }

        private double _Value;

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(HsvBoxBackgroundEffect),
                new PropertyMetadata(
                    Boxes.Double0,
                    (s, e) =>
                    {
                        var self = (HsvBoxBackgroundEffect) s;
                        self._Value = (double) e.NewValue;

                        PixelShaderConstantCallback(0)(s, e);
                    }));

        #endregion
    }
}