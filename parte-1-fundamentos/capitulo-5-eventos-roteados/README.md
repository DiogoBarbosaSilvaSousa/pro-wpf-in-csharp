# Eventos Roteados

Todo desenvolvedor .NET está familiarizado com a ideia de ***eventos (events)*** - mensagens que são enviadas por um objeto (como um Elemento WPF) para notificar seu código quando algo significativo ocorrer. WPF aprimora o evento .NET modelo com o conceito de ***roteamento de eventos (event routing)***. O roteamento de eventos permite que um evento se origine em um elemento, mas seja criado por outro. Por exemplo, o roteamento de eventos permite que um clique que começa em um botão da barra de ferramentas suba para a barra de ferramentas e, em seguida, para a janela que o contém antes de ser tratado pelo seu código. O roteamento de eventos oferece a flexibilidade de escrever um código bem organizado que lida com eventos no lugar mais conveniente. Também é uma necessidade para trabalhar com o modelo de conteúdo WPF, que permite você construir elementos simples (como um botão) com dezenas de ingredientes distintos, cada um com seu próprio conjunto independente de eventos.

## Bubbling Events (Eventos borbulhantes)

A Figura abaixo mostra uma janela simples que demonstra o borbulhamento de eventos. Quando você clica em uma parte do rótulo, a sequência de eventos é mostrada em uma caixa de listagem. Depois de clicar na imagem no rótulo é exibida a sequência de eventos na Listbox. O evento MouseUp viaja por cinco níveis, terminando no formulário personalizado BubbledLabelClick. Se você deixar o CheckBox "Manipulando o primeieo evento" só exibirá o primeiro evento do clique caso contrário será exibido os cinco eventos como falado anteriormente.

![BubbledLabelClick](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/02.png)

***Checkbox Marcado***

![BubbledLabelClick](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/01.png)

***Arquivo MainWindow.xaml***
```
<Window x:Class="BubbledLabelClick.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:BubbledLabelClick"
        mc:Ignorable="d"
        Title="BubbledLabelClick" Height="550" Width="400" MouseUp="SomethingClicked">
    <Grid Margin="3" MouseUp="SomethingClicked">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>

        <Label Margin="5" Grid.Row="0" HorizontalAlignment="Left" Background="AliceBlue" BorderBrush="Black" BorderThickness="1"
 MouseUp="SomethingClicked">
            <StackPanel MouseUp="SomethingClicked">
                <TextBlock Margin="3"  MouseUp="SomethingClicked">
                    Rótulo de imagem e texto
                </TextBlock>
                <Image Source="/components/Images/happyface.png" Stretch="Fill" MouseUp="SomethingClicked" Width="50" Height="50"/>
                <TextBlock Margin="3"  MouseUp="SomethingClicked">
                    Cortesia do StackPanel
                </TextBlock>
            </StackPanel>
        </Label>

        <ListBox Grid.Row="1" Margin="5" Name="lstMessages"></ListBox>
        <CheckBox Grid.Row="2" Margin="5" Name="chkHandle">
            Manipulando o primeiro evento
        </CheckBox>
        <Button Grid.Row="3" Margin="5" Padding="3" HorizontalAlignment="Right" Name="cmdClear" Click="cmdClear_Click">
        Limpar lista
        </Button>
    </Grid>
</Window>
```

***Arquivo MainWindow.xaml.cs***
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BubbledLabelClick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int eventCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SomethingClicked(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
            " Sender(Remetente): " + sender.ToString() + "\r\n" +
            " Source(Fonte): " + e.Source + "\r\n" +
            " Original Source(Fonte original): " + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;

        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
        }
    }
}

```

## Eventos Anexados (Attached Events)

O exemplo de rótulo extravagante é um exemplo bastante simples de borbulhamento de evento porque todos os elementos apoiam o evento MouseUp. No entanto, muitos controles têm seus próprios eventos mais especializados. O botão é um exemplo - adiciona um evento Click que não é definido por nenhuma classe base. Isso introduz um dilema interessante. Imagine que você envolve uma pilha de botões em um StackPanel. Vocês deseja lidar com todos os cliques de botão em um manipulador de eventos. A abordagem crua é anexar o evento Click de cada botão para o mesmo manipulador de eventos. Mas o evento Click oferece suporte ao borbulhamento de eventos, o que dá a você um melhor opção. Você pode controlar todos os cliques de botão manipulando o evento Click em um nível superior (como o contendo StackPanel).
Infelizmente, esse código aparentemente óbvio não funciona:

```
<StackPanel Click="DoSomething" Margin="5">
 <Button Name="cmd1">Comando 1</Button>
 <Button Name="cmd2">Comando 2</Button>
 <Button Name="cmd3">Comando 3</Button>
</StackPanel>
```

O problema é que o StackPanel não inclui um evento Click, então isso é interpretado pelo analisador XAML como um erro. A solução é usar uma sintaxe de evento anexado diferente na forma ***ClassName.EventName*** . Aqui está o exemplo corrigido:

```
<StackPanel  Button.Click="DoSomething" Margin="5">
        <Button Name="cmd1" Tag="The first button." Margin="5">Comando 1</Button>
        <Button Name="cmd2" Tag="The second button." Margin="5">Comando 2</Button>
        <Button Name="cmd3" Tag="The third button." Margin="5">Comando 3</Button>
</StackPanel>
```

***Código do método usado na chamada de evento ali eu mostro duas formas de capturar informações uma através do Name do Button outra acessando uma de suas propriedades***

```
private void DoSomething(object sender, RoutedEventArgs e)
{
            Button cmd = (Button)e.OriginalSource;
            MessageBox.Show((string)cmd.Tag);

            if (e.Source == cmd1)
            { MessageBox.Show("cmd1"); }
            else if (e.Source == cmd2)
            { MessageBox.Show("cmd2"); }
            else if (e.Source == cmd3)
            { MessageBox.Show("cmd3"); }
}
```

![AttachedEvents](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/03.png)

## Tunneling Events (Eventos de tunelamento)

Os eventos de túnel funcionam da mesma forma que os eventos de bolha, mas na direção oposta. Por exemplo, se MouseUp era um evento encapsulado (o que não é), clicar na imagem no exemplo de rótulo extravagante causaria MouseUp para disparar primeiro na janela, depois no Grid, depois no StackPanel e assim por diante, até atingir o fonte real, que é a imagem no rótulo. 
Os eventos de encapsulamento são fáceis de reconhecer porque começam com a palavra ***Preview***. Além disso o WPF geralmente define eventos de bubbling e tunneling em pares. Isso significa que se você encontrar um evento Borbulhante de MouseUp, você provavelmente também pode encontrar um evento PreviewMouseUp de tunelamento. O evento de tunelamento sempre dispara antes do evento de borbulhamento, conforme mostrado na Figura.

![Contexto dos eventos](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/04.png)

***Eventos de Tunelamento***

![Eventos de Tunelamento](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/05.png)

***Arquivo MainWindow.xaml***

```
<Window x:Class="TunneledKeyPress.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TunneledKeyPress"
        mc:Ignorable="d"
        Title="TunneledKeyPress" Height="650" Width="450" PreviewKeyDown="SomeKeyPressed">
    <Grid Margin="3">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>

        <Label Margin="5" Background="AliceBlue" BorderBrush="Black" BorderThickness="1" HorizontalContentAlignment="Stretch"
           PreviewKeyDown="SomeKeyPressed">
            <StackPanel
        PreviewKeyDown="SomeKeyPressed">
                <TextBlock Margin="3" HorizontalAlignment="Center"
                   PreviewKeyDown="SomeKeyPressed">
                              Rótulo de imagem e texto
                </TextBlock>
                <Image Source="/components/Images/happyface.png" Stretch="Fill"  PreviewKeyDown="SomeKeyPressed"
                       Width="50" Height="50"/>
                <DockPanel Margin="0,5,0,0" PreviewKeyDown="SomeKeyPressed">
                    <TextBlock Margin="3" 
                     PreviewKeyDown="SomeKeyPressed">
          Digite aqui:
                    </TextBlock>
                    <TextBox PreviewKeyDown="SomeKeyPressed" KeyDown="SomeKeyPressed"></TextBox>
                </DockPanel>
            </StackPanel>
        </Label>

        <ListBox Margin="5" Name="lstMessages" Grid.Row="1"></ListBox>
        <CheckBox Margin="5" Grid.Row="2" Name="chkHandle">Manipulando o primeiro evento</CheckBox>
        <Button Click="cmdClear_Click" Grid.Row="3" HorizontalAlignment="Right" Margin="5" Padding="3">Limpar Lista</Button>

    </Grid>
</Window>
```

***Arquivo MainWindow.xaml.cs***

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TunneledKeyPress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int eventCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SomeKeyPressed(object sender, KeyEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
            " Sender(Remetente): " + sender.ToString() + "\r\n" +
            " Source(Fonte): " + e.Source + "\r\n" +
            " Original Source(Fonte original): " + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;

        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            lstMessages.Items.Clear();
        }
    }
}
```

![TunneledKeyPress](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/06.png)

## Manuseio de uma tecla pressionada (Handling a Key Press)

A melhor maneira de entender os eventos principais(eventos do teclado - ***key press***) é usar um programa de amostra, como o mostrado na Figura. Ele monitora uma caixa de texto para todos os eventos-chave e relatórios possíveis quando eles ocorrem. A Figura mostra o resultado de digitar um S maiúsculo em uma caixa de texto.


Este exemplo ilustra um ponto importante. Os eventos PreviewKeyDown e KeyDown disparam a cada vez que uma tecla é pressionada. No entanto, o evento TextInput é disparado apenas quando um caractere é “digitado” em um elemento. Na verdade, essa ação pode envolver vários pressionamentos de tecla. No exemplo da Figura 5-5, dois pressionamentos de tecla são
necessário para criar a letra S maiúscula. Primeiro, a tecla Shift é pressionada, seguida pela tecla S. Como resultado, você veja dois eventos KeyDown e KeyUp, mas apenas um evento TextInput. Os eventos PreviewKeyDown, KeyDown, PreviewKeyUp e KeyUp fornecem as mesmas informações por meio do objeto KeyEventArgs. O detalhe mais importante é a propriedade Key, que retorna um valor da enumeração System.Windows.Input.Key que identifica a tecla que foi pressionada ou liberada. Este é o manipulador de eventos que lida com eventos-chave para o exemplo da Figura acima:

```
private void KeyEvent(object sender, KeyEventArgs e)
{
         string message = "Event(Evento): " + e.RoutedEvent + " " +
         " Key(Tecla): " + e.Key;
         lstMessages.Items.Add(message);
}
```

O valor da Chave(Tecla - ***Key***) não leva em consideração o estado de nenhuma outra chave(Tecla). Por exemplo, não importa se a tecla Shift está atualmente pressionada quando você pressiona a tecla S; de qualquer forma, você obterá a mesma chave valor (Key.S).
Há mais um pequeno contratempo. Dependendo das configurações do teclado do Windows, pressionar uma tecla causa o "pressionamento de tecla a ser repetido" após um pequeno atraso (manter a tecla pressionada pode causa vários "disparos de eventos"). Por exemplo, manter pressionada a tecla S obviamente coloca um fluxo de S caracteres na caixa de texto. Da mesma forma, pressionar a tecla Shift causa vários pressionamentos de tecla e uma série de Eventos KeyDown. Em um teste do mundo real em que você pressiona Shift + S, sua caixa de texto irá disparar uma série de Eventos KeyDown para a tecla Shift, seguidos por um evento KeyDown para a tecla S, um evento TextInput (ou Evento TextChanged no caso de uma caixa de texto) e, em seguida, um evento KeyUp para as teclas Shift e S. Se você quiser para ignorar essas teclas Shift repetidas, você pode verificar se um pressionamento de tecla é o resultado de uma tecla que está sendo pressionada examinando a propriedade KeyEventArgs.IsRepeat, conforme mostrado aqui:

```
if ((bool)chkIgnoreRepeat.IsChecked && e.IsRepeat) return;
```

***Dica*** : Os eventos PreviewKeyDown, KeyDown, PreviewKeyUp e KeyUp são melhores para escrever manipulações de teclado de baixo nível (raramente precisará de um controle personalizado) e manipulação de pressionamentos de teclas especiais.


Depois que o evento KeyDown ocorre, o evento PreviewTextInput segue. (O evento TextInput não ocorre, porque o TextBox suprime este evento.) Neste ponto, o texto ainda não apareceu na caixa de controle.  O evento TextInput fornece seu código com um objeto TextCompositionEventArgs. Este objeto inclui uma propriedade Text que fornece o texto processado que está prestes a ser recebido pelo controle. Aqui está o código que adiciona este texto à lista mostrada na Figura anterior:

```
private void TextInput(object sender, TextCompositionEventArgs e)
{
     string message = "Event: " + e.RoutedEvent + " " +
       " Text: " + e.Text;
     lstMessages.Items.Add(message);
}
```

Idealmente, você usaria PreviewTextInput para realizar a validação em um controle como o TextBox. Para por exemplo, se você estiver construindo uma caixa de texto apenas numérica, pode ter certeza de que o pressionamento de tecla atual não é um letra e definir o sinalizador Handled se for. Infelizmente, o evento PreviewTextInput não dispara para algumas chaves que você pode precisar lidar. Por exemplo, se você pressionar a barra de espaço em uma caixa de texto, você contornará PreviewTextInput completamente. Isso significa que você também precisa lidar com o evento PreviewKeyDown. Infelizmente, é difícil escrever uma lógica de validação robusta em um manipulador de eventos PreviewKeyDown
porque tudo o que você tem é o valor-chave, que é uma informação de nível bastante baixo. Por exemplo, a chave enumeração distingue entre o teclado numérico e as teclas numéricas que aparecem logo acima do letras em um teclado típico. Isso significa que, dependendo de como você pressiona o número 9, pode obter um valor de Key.D9 ou Key.NumPad9. Verificar todos os valores-chave permitidos é entediante, para dizer o mínimo. Uma opção é usar o KeyConverter para converter o valor da chave em uma string mais útil. Por exemplo, usando KeyConverter.ConvertToString () em Key.D9 e Key.NumPad9 retorna “9” como uma string. Se você apenas usar a conversão Key.ToString (), você obterá o nome de enumeração muito menos útil ("D9" ou “NumPad9”):

```
KeyConverter converter = new KeyConverter();
string key = converter.ConvertToString(e.Key);
```

No entanto, mesmo usar o KeyConverter é um pouco estranho porque você vai acabar com pedaços de texto mais longos (como “Backspace”) para pressionamentos de tecla que não resultam em entrada de texto. O melhor compromisso é lidar com PreviewTextInput (que cuida da maior parte da validação) e use PreviewKeyDown para pressionamentos de tecla que não aumentem PreviewTextInput na caixa de texto (como o barra de espaço). Aqui está uma solução simples que faz isso:

```
private void pnl_PreviewTextInput(object sender, TextCompositionEventArgs e)
{
         short val;
         if (!Int16.TryParse(e.Text, out val))
         {
                 // Disallow non-numeric key presses.
                 e.Handled = true;
         }
}

private void pnl_PreviewKeyDown(object sender, KeyEventArgs e)
{
         if (e.Key == Key.Space)
         {
                 // Disallow the space key, which doesn't raise a PreviewTextInput event.
                 e.Handled = true;
         }
}
```

Você pode anexar esses manipuladores de eventos a uma única caixa de texto ou conectá-los a um contêiner (como um StackPanel que contém várias caixas de texto apenas numéricas) para maior eficiência.

***Nota***
>Esse comportamento de manipulação de teclas pode parecer desnecessariamente estranho (e é). Uma das razões pelas quais o
O TextBox não fornece um melhor manuseio de chaves é que o WPF se concentra na vinculação de dados, um recurso que permite que você conecte
controles como o TextBox para objetos personalizados. Quando você usa essa abordagem, a validação geralmente é fornecida pelo
objeto vinculado, os erros são sinalizados por uma exceção e dados inválidos acionam uma mensagem de erro que aparece em algum lugar na interface do usuário. Infelizmente, não há uma maneira fácil (no momento) de combinar a vinculação de dados de alto nível útil recurso com o manuseio do teclado de nível inferior que seria necessário para evitar que o usuário digite completamente alguns caracteres.
