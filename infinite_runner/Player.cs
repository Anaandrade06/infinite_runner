using System.Security.Cryptography.X509Certificates;
using __XamlGeneratedCode__;

public delegate void Callback();
public class Player : Animacao
{
    public Player( Image A): base(A)
{
    for (int i = 1; i <= 2; ++i)
     Animacao01.Add($"Andaar{ i.ToString("D2")}.png");
     for (int i = 1 ; i <= 2; ++i)
     Animacao02.Add($"Morreu{i .ToString("D2")}.png");

     SetAnimacaoAtiva(1);
}
public void Morto()
        {
            Loop = false;
            SetAnimacaoAtiva(2);
        }

        public void Run()
        {
            Loop = true;
            SetAnimacaoAtiva(1);
            Play();
        }















}