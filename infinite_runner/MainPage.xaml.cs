
using FFImageLoading.Maui;

namespace infinite_runner;
public partial class MainPage : ContentPage
{
	bool estaMorto = false;
	bool estaNoChao = false;
	bool estaNoAr = false;
	bool estaPulando = false;
	int tempoPulando = 0;
	int tempoNoAr = 0;
	const int forcaPulo = 8;
	const int maxTempoPulado = 6;
	const int maxTempoNoAr = 4;
	const int tempoEntreFrames = 25;
	const int forcaGravidade = 6;
	int Velocidade1 = 0;
	int Velocidade2 = 0;
	int Velocidade3 = 0;
	int Velocidade = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;
	Player player;

	public MainPage()
	{
		InitializeComponent();
	}
	protected CachedImageView ImageView;
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
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
			if (!estaPulando && !estaNoAr)
			{
				AplicaGravidade();
				player.Desenha();
			}
			else
				AplicaPulo();

			await Task.Delay(tempoEntreFrames);
		}
	}
 void AplicaGravidade()
 {
	if
	 (player.GetY()<0)
		player.MoveY(forcaGravidade);
	
	else if 
	(player.GetY()>= 0);
	{
		player.SetY(0);
		estaNoChao = true;
	} 
 }
 void AplicaPulo()
 {
	estaNoChao=false;
	if(estaPulando&&tempoPulando>= maxTempoPulado)
	{
		estaPulando = false;
		estaNoAr = true;
		tempoNoAr = 0;
	}
	else if (estaNoAr&&tempoNoAr>=maxTempoNoAr)
	{
		estaPulando = false;
		estaNoAr = false;
		tempoPulando = 0;
		tempoNoAr = 0;
	}
else if (estaPulando&&tempoPulando <maxTempoPulado)
{
	player .MoveY(-forcaPulo);
	tempoPulando++;
}
else if (estaNoAr)
tempoNoAr++;
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
	{
		HSLayer1.TranslationX -= Velocidade1;
		HSLayer2.TranslationX -= Velocidade2;
		HSLayer3.TranslationX -= Velocidade3;
		HSLayerchao.TranslationX -= Velocidade;
	}
	void CalculaVelocidade(double w)
	{
		Velocidade1 = (int)(w * 0.001);

		Velocidade2 = (int)(w * 0.004);

		Velocidade3 = (int)(w * 0.008);

		Velocidade = (int)(w * 0.02);
	}
	void GerenciaCenario(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}

	}
	void CorrigeTamanhoCenario(double w, double h)
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