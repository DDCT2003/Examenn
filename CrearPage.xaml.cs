using Examen.Models;
using Examen.Service;

namespace Examen;

public partial class CrearPage : ContentPage
{
    private readonly APIService _ApiService;
    private readonly Tarea _Tarea;
    public CrearPage(APIService apiservice)
	{
        _ApiService = apiservice;
        InitializeComponent();
	}

    private async void CrearButton(object sender, EventArgs e)
    {
        _Tarea.Nombre = Nombre.ToString();
        _Tarea.Estado = Estado.ToString();
        _Tarea.Tareas = Tarea.ToString();

        await _ApiService.PostTarea(_Tarea);
    }
}