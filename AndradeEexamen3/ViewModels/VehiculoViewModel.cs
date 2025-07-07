using AndradeEexamen3.Models;
using AndradeEexamen3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AndradeEexamen3.ViewModels;

public class VehiculoViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Vehiculo> Vehiculos { get; set; } = new();
    public Vehiculo NuevoVehiculo { get; set; } = new();

    public ICommand GuardarCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    private VehiculoDatabase _db;

    public VehiculoViewModel()
    {
        _db = App.VehiculoDB;
        GuardarCommand = new Command(async () => await GuardarVehiculo());
        CargarVehiculos();
    }

    private async Task GuardarVehiculo()
    {
        if (NuevoVehiculo.AnioFabricacion < 1990 || NuevoVehiculo.AnioFabricacion > DateTime.Now.Year)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "El año debe estar entre 1990 y el actual.", "OK");
            return;
        }

        await _db.SaveVehiculoAsync(NuevoVehiculo);
        await FileLoggerService.AppendLogAsync(NuevoVehiculo.Marca);
        NuevoVehiculo = new Vehiculo();
        await CargarVehiculos();
        OnPropertyChanged(nameof(NuevoVehiculo));
    }

    private async Task CargarVehiculos()
    {
        var lista = await _db.GetVehiculosAsync();
        Vehiculos.Clear();
        foreach (var v in lista)
            Vehiculos.Add(v);
    }

    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}