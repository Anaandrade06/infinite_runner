using FFImageLoading.Maui;

namespace infinite_runner
{
public class Animacao
{
    protected List<String> Animacao01 = new List<String>();
    protected List<String> Animacao02 = new List<String>();
    protected List<String> Animacao03 = new List<String>();
    public bool Loop = true;
    protected int AnimacaoAtiva = 1;
    
    bool Brush = true;
    int MainFrame = 1;
    
    protected CachedImageView ImageView;

    public Animacao(CachedImageView imagem)
    {
        ImageView = imagem;
    }
    public void Stop()
    {
        Brush = true;
    }
    public void Play()
    {
         Brush = false;
    }
    public void SetAnimacaoAtiva(int A)
    {
        AnimacaoAtiva = A;
    }
    public void Desenha()
    {
        if (Brush)
            return;
        string NomeArquivo = "";
        int AnimationHeigth = 0;
        if (AnimacaoAtiva == 1)
        {
            NomeArquivo = Animacao01[MainFrame];
            AnimationHeigth = Animacao01.Count;
        }
        else if (AnimacaoAtiva == 2)
        {
            NomeArquivo = Animacao02[MainFrame];
            AnimationHeigth = Animacao02.Count;
        }
        else if (AnimacaoAtiva == 3)
        {
            NomeArquivo = Animacao03[MainFrame];
            AnimationHeigth = Animacao03.Count;
        }
        ImageView.Source = ImageSource.FromFile(NomeArquivo);
        MainFrame++;
        if (MainFrame >= AnimationHeigth)
        {
            if (Loop)
                MainFrame = 0;
            else
            {
                 Brush = true;
                OnStop();
            }
        }
    }
    public virtual void OnStop()
    {

    }
}
}