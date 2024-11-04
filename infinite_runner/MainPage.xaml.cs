
namespace infinite_runner;
public partial class MainPage : ContentPage
{
bool estaMorto = false;
bool estaPulando = false;
const int tempoEntreFrames = 25;
int Velocidade1 = 0;
int Velocidade2 = 0;
int Velocidade3 = 0;
int Velocidade = 0;
int larguraJanela = 0;
int alturaJanela = 0;

public MainPage()
{
	InitializeComponent();
}
protected override void OnSizeAllocated(double w, double h)
{
	base.OnSizeAllocated(w, h);
	CorrigeTamanhoCenario(w, h);
	CalculaVelocidade(w);
}
async Task Desenha()
{
	while (!estaMorto)
	{
	GerenciaCenarios();
	await Task.Delay (tempoEntreFrames);
	}
}
void GerenciaCenarios()
{
MoveCenario();
GerenciaCenario(HSLayer1);
GerenciaCenario(HSLayer2);
GerenciaCenario(HSLayer3);
GerenciaCenario(HSLayerchao);
}
void MoveCenario()
{HSLayer1. TranslationX -= Velocidade1;
HSLayer2. TranslationX -= Velocidade2;
HSLayer3. TranslationX -= Velocidade3;
HSLayerchao. TranslationX -= Velocidade;
}
void CalculaVelocidade (double w)
{
Velocidade1= (int) (w * 0.001);

Velocidade2= (int) (w * 0.004);

Velocidade3= (int) (w * 0.008);

Velocidade= (int) (w * 0.01);
}
void GerenciaCenario(HorizontalStackLayout HSL)
{
	var view =(HSL.Children. First() as Image);
	if (view.WidthRequest+HSL.TranslationX < 0)
	{
		HSL.Children.Remove(view);
		HSL.Children.Add(view);
		HSL.TranslationX = view.TranslationX; 
	}
	
	}
void CorrigeTamanhoCenario (double w, double h)
{

	foreach (var A in HSLayer1.Children)
		(A as Image).WidthRequest = w;

	foreach (var A in HSLayer2.Children)
	(A as Image).WidthRequest = w;

	foreach (var A in HSLayer3.Children)
	(A as Image).WidthRequest = w;

	foreach (var A in HSLayerchao.Children)
		(A as Image).WidthRequest = w;

HSLayer1.WidthRequest = w;
HSLayer2.WidthRequest = w;
HSLayer3.WidthRequest = w;
HSLayerchao.WidthRequest = w;
}
}