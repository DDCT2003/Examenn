using Examen.Models;
using Examen.Service;
using System.Collections.ObjectModel;



namespace Examen;

public partial class InicioPage : ContentPage
{

    private readonly APIService _ApiService;
    public InicioPage(APIService apiservice)

	{
        _ApiService = apiservice;

        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Tarea> listaTareas = await _ApiService.GetTareas();
        var tareas = new ObservableCollection<Tarea>(listaTareas);
        ListaTareas.ItemsSource = tareas;
    }

    private async void Btn_Buscar(object sender, EventArgs e)
    {
        List<Tarea> listaTareas = await _ApiService.GetTarea(Nombre.ToString(),Estado.ToString()) ;
        var tareas = new ObservableCollection<Tarea>(listaTareas);
        ListaTareas.ItemsSource = tareas;
    }

    private async void Btn_Crear(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearPage(_ApiService));
    }
}