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
    protected Image compImagem;
        private bool  Stopped = true;

    public Animacao(CachedImageView imagem)
    {
        compImagem = imagem;
    }
    public void Stop()
    {
         Stopped = true;
    }
    public void Play()
    {
         Stopped = false;
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
        compImagem.Source = ImageSource.FromFile(NomeArquivo);
        MainFrame++;
        if (MainFrame >= AnimationHeigth)
        {
            if (Loop)
                MainFrame = 0;
            else
            {
                 Stopped = true;
                OnStop();
            }
        }
    }
    public virtual void OnStop()
    {

    }
}
}