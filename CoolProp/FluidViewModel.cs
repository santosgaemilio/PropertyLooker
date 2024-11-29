using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using SharpProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace CoolProp
{
    public partial class FluidViewModel : ObservableValidator
    {
        public Fluid CurrentFluid { get; set; }
        public List<FluidsList> Fluids { get; set; }
        public FluidViewModel(FluidsList _fluidName)
        {
            SelectedName = _fluidName;
            CurrentFluid = new Fluid(_fluidName);
            CurrentFluid.Update(Input.Temperature(new(298.15, UnitsNet.Units.TemperatureUnit.Kelvin)),
                                Input.Pressure(new Pressure(101.325, UnitsNet.Units.PressureUnit.Kilopascal)));
            Phase = CurrentFluid.Phase;
            Density = CurrentFluid.Density;
            CompressionFactor = CurrentFluid.Compressibility;
            Quality = CurrentFluid.Fraction;
            Fluids = Enum.GetValues(typeof(FluidsList)).Cast<FluidsList>().ToList();
        }
        [ObservableProperty]
        double temp = 298.15; //K
        [ObservableProperty]
        double press = 101.325; //kPa
        [ObservableProperty]
        double? compressionFactor;
        public string Name => CurrentFluid.Name.ToString();
        [ObservableProperty]
        Phases phase;
        [ObservableProperty]
        Density density;
        [ObservableProperty]
        Ratio quality;
        [ObservableProperty]
        FluidsList selectedName;
        partial void OnSelectedNameChanged(FluidsList value)
        {
            CurrentFluid = new Fluid(value);
            CurrentFluid.Update(Input.Temperature(new(Temp, UnitsNet.Units.TemperatureUnit.Kelvin)),
                                Input.Pressure(new Pressure(Press, UnitsNet.Units.PressureUnit.Kilopascal)));
            Phase = CurrentFluid.Phase;
            Density = CurrentFluid.Density;
            CompressionFactor = CurrentFluid.Compressibility;
            Quality = CurrentFluid.Fraction;
        }
        [RelayCommand]
        public void UpdateFluid()
        {
            CurrentFluid.Update(Input.Temperature(new(Temp, UnitsNet.Units.TemperatureUnit.Kelvin)),
                                Input.Pressure(new Pressure(Press, UnitsNet.Units.PressureUnit.Kilopascal)));
            Phase = CurrentFluid.Phase;
            Density = CurrentFluid.Density;
            CompressionFactor = CurrentFluid.Compressibility;
            Quality = CurrentFluid.Fraction;
        }
    }
}
