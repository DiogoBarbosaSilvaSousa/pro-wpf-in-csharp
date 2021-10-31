# Layout

## Layout simples com o StackPanel
<p>O StackPanel é um dos contêineres de layout mais simples. Ele simplesmente empilha seus filhos em uma única linha ou coluna.</p>
<p>Por exemplo, considere esta janela, que contém uma pilha de quatro botões:</p>

![SimpleStackPanel](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/09.png)

<p>Código XAML</p>

![SimpleStackPanel](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/10.png)

### Propriedades de layout

- **HorizontalAlignment** : Determina como um filho é posicionado dentro de um contêiner de layout quando há espaço horizontal disponível. Você pode escolher Center, Left, Right, ou Stretch.

- **VerticalAlignment** : Determina como um filho é posicionado dentro de um contêiner de layout quando há espaço vertical disponível. Você pode escolher Center, Top, Bottom, ou Stretch.

- **Margin** : Adiciona um pouco de espaço para respirar em torno de um elemento. A propriedade Margin é um instância da estrutura System.Windows.Thickness, com componentes separados para a borda top, bottom, left e right.

- **MinWidth and MinHeight** :Define as dimensões máximas de um elemento. Se o contêiner tiver mais espaço disponível, o elemento não será ampliado além desses limites, mesmo se o
as propriedades HorizontalAlignment e VerticalAlignment são definidas como Stretch.

- **Width and Height** : Define explicitamente o tamanho de um elemento. Esta configuração substitui um valor Stretch para o Propriedades HorizontalAlignment ou VerticalAlignment. No entanto, este tamanho não será honrado se estiver fora dos limites definidos pelo MinWidth, MinHeight, MaxWidth e MaxHeight.

#### Alignment (Alinhamento)
![SimpleStack](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/11.png)

<p>
 O tamanho usado na minha janela (Window) foi Height="223" Width="354" .
</p>


```
    <StackPanel>
        <Label HorizontalAlignment="Center">Uma pilha de botões</Label>
        <Button HorizontalAlignment="Left">Botão 1</Button>
        <Button HorizontalAlignment="Right">Botão 2</Button>
        <Button>Botão 3</Button>
        <Button>Botão 4</Button>
    </StackPanel>
```

### Margin (Margem)
![SimpleStack](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/12.png)

```
 <StackPanel Margin="3">
        <Label Margin="3" HorizontalAlignment="Center">
            Uma pilha de botões
        </Label>
        <Button Margin="3" HorizontalAlignment="Left">Botão 1</Button>
        <Button Margin="3" HorizontalAlignment="Right">Botão 2</Button>
        <Button Margin="3">Botão 3</Button>
        <Button Margin="3">Botão 4</Button>
    </StackPanel>
```
### Minimum, Maximum, and Explicit Sizes (Mínimo, máximo e tamanho explícito)

![SimpleStack](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/13.png)

**Dica** : Pense duas vezes antes de definir um tamanho explícito no WPF. Em um layout bem projetado, não deve ser necessário. Se você
adicionar informações de tamanho, você corre o risco de criar um layout mais frágil que não pode se adaptar às mudanças (como
idiomas e tamanhos de janela) e trunca seu conteúdo.

```
<StackPanel Margin="3">
        <Label Margin="3" HorizontalAlignment="Center">
            Uma pilha de botões
        </Label>
        <Button Margin="3" MaxWidth="200" MinWidth="100">Botão 1</Button>
        <Button Margin="3" MaxWidth="200" MinWidth="100">Botão 2</Button>
        <Button Margin="3" MaxWidth="200" MinWidth="100">Botão 3</Button>
        <Button Margin="3" MaxWidth="200" MinWidth="100">Botão 4</Button>
    </StackPanel>
```

### The Border (A Borda)

![SimpleStack](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/14.png)

- Background : Define um plano de fundo que aparece atrás de todo o conteúdo na borda usando um objeto de pincel. Você pode usar uma cor sólida ou algo mais exótico.

- BorderBrush and BorderThickness : Define a cor da borda que aparece na borda do objeto Borda, usando um Objeto de pincel e define a largura da borda, respectivamente. Para mostrar uma fronteira, você deve definir ambas as propriedades.

- CornerRadius : Permite que você contorne graciosamente os cantos de sua borda. Quanto maior o CornerRadius, mais dramático é o efeito de arredondamento.

- Padding : Adiciona espaçamento entre a borda e o conteúdo interno. (Por outro lado, Margin adiciona espaçamento fora da borda.)

```
<Border Margin="5" Padding="5" Background="LightYellow" BorderBrush="SteelBlue" 
            BorderThickness="3,5,3,5" CornerRadius="3" VerticalAlignment="Top">
        <StackPanel>
            <Button Margin="3">Um</Button>
            <Button Margin="3">Dois</Button>
            <Button Margin="3">Três</Button>
        </StackPanel>
    </Border>
```

## O WrapPanel e  DockPanel

<p>
Obviamente, o StackPanel sozinho não pode ajudá-lo a criar uma interface de usuário realista. Para completar a imagem, o
StackPanel precisa trabalhar com outros contêineres de layout mais capazes. Só então você pode montar uma janela completa.
</p>

<p>
O contêiner de layout mais sofisticado é o Grid, que você considerará posteriormente neste capítulo. Mas rimeiro, vale a pena olhar para WrapPanel e DockPanel, 
 que são mais dois do layout simples de contêineres fornecidos pela WPF. Eles complementam o StackPanel, oferecendo diferentes comportamentos de layout.
</p>

### O WrapPanel

<p> 
O WrapPanel apresenta os controles no espaço disponível, uma linha ou coluna por vez. Por padrão, o propriedade WrapPanel.Orientation é definida como Horizontal; os controles são organizados da esquerda para a direita e, em seguida, linhas subsequentes. No entanto, você pode usar Vertical para colocar elementos em várias colunas.
</p>

O tamanho da janela (Window) Height="200" Width="440".

```
 <WrapPanel Margin="3">
        <Button VerticalAlignment="Top">Botão em cima</Button>
        <Button MinHeight="60">Botão Alto</Button>
        <Button VerticalAlignment="Bottom">Botão em baixo</Button>
        <Button>Botão esticado</Button>
        <Button VerticalAlignment="Center">Botão centralizado</Button>
    </WrapPanel>
```

![SimpleWrapPanel](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/15.png)

<p>
A Figura mostra como os botões são agrupados para caber no tamanho atual do WrapPanel (que é determinado pelo tamanho da janela que o contém). Como este exemplo demonstra, um WrapPanel em o modo horizontal cria uma série de linhas imaginárias, cada uma delas com a altura da mais altaelemento contido. Outros controles podem ser esticados para caber ou alinhados de acordo com o VerticalAlignment propriedade. No exemplo à esquerda na Figura, todos os botões se encaixam em uma linha alta e são esticados ou alinhado para caber. No exemplo à direita, vários botões foram colocados na segunda linha. Porque a segunda linha não inclui um botão excepcionalmente alto, a altura da linha é mantida no botão mínimo altura. Como resultado, não importa qual configuração de VerticalAlignment os vários botões nesta linha usam.
</p>

## DockPanel

<p>
O DockPanel é uma opção de layout mais interessante. Ele estende os controles contra uma de suas bordas externas.
A maneira mais fácil de visualizar isso é pensar nas barras de ferramentas que ficam na parte superior de muitos aplicativos do Windows.
Essas barras de ferramentas são encaixadas na parte superior da janela. Tal como acontece com o StackPanel, os elementos encaixados podem escolher
um aspecto de seu layout.
</p>

<p>
Por exemplo, se você encaixar um botão na parte superior de um DockPanel, ele é esticado por toda a largura do DockPanel, mas dada a altura necessária (com base no conteúdo e na propriedade MinHeight). Por outro lado, se você encaixar um botão no lado esquerdo de um contêiner, sua altura será
esticada para caber no contêiner, mas sua largura é livre para crescer conforme necessário.
</p>

<p>
A pergunta óbvia é: como os elementos filhos escolhem o lado onde desejam encaixar? A resposta é por meio de uma propriedade anexada chamada Dock, que pode ser definida como Left, Right, Top ou Bottom. Cada elemento que é colocado dentro de um DockPanel adquire automaticamente esta propriedade. 
Aqui está um exemplo que coloca um botão em cada lado de um DockPanel:
</p>

Este exemplo também define LastChildFill como true, o que diz ao DockPanel para fornecer o espaço restante para o último elemento.
```
<DockPanel LastChildFill="True">
        <Button DockPanel.Dock="Top">Botão superior</Button>
        <Button DockPanel.Dock="Bottom">Botão inferior</Button>
        <Button DockPanel.Dock="Left">Botão esquerda</Button>
        <Button DockPanel.Dock="Right">Botão direito</Button>
        <Button>Espaço restante</Button>
    </DockPanel>
```

![SimpleDockPanel](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/16.png)

### Ordenação

<p>
 Claramente, ao encaixar os controles, a ordem é importante. Neste exemplo, os botões superior e inferior obtem a largura total do DockPanel porque eles são encaixados primeiro. Quando os botões esquerdo e direito são encaixados em seguida, eles se encaixam entre esses dois botões. Se você inverter esta ordem, os botões esquerdo e direito ocuparão o
lados inteiros, e os botões superior e inferior se tornariam mais estreitos porque seriam encaixados entre os dois botões laterais.
 
 ```
<DockPanel LastChildFill="True">
        <Button DockPanel.Dock="Left">Botão esquerda</Button>
        <Button DockPanel.Dock="Right">Botão direito</Button>
        <Button DockPanel.Dock="Top">Botão superior</Button>
        <Button DockPanel.Dock="Bottom">Botão inferior</Button>        
        <Button>Espaço restante</Button>
    </DockPanel>
 ```
 
</p>
 
 ![SimpleDockPanel](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/17.png)
 
<p> 
Você pode encaixar vários elementos no mesmo lado. Neste caso, os elementos simplesmente empilham contra o lado na ordem em que são declarados em sua marcação. E se você não gosta do espaçamento ou do comportamento de alongamento, você pode ajustar as propriedades Margin, HorizontalAlignment e VerticalAlignment, apenas
como você fez com o StackPanel. Aqui está uma versão modificada do exemplo anterior que ajusta o alinhamento:
 </p>
 
 ```
 <DockPanel LastChildFill="True">
        <Button DockPanel.Dock="Top">Um botão superior esticado</Button>
        <Button DockPanel.Dock="Top" HorizontalAlignment="Center">
            Um botão superior centralizado</Button>
        <Button DockPanel.Dock="Top" HorizontalAlignment="Left">
            Um botão superior alinhado à esquerda</Button>
        <Button DockPanel.Dock="Bottom">Botão inferior</Button>
        <Button DockPanel.Dock="Left"> Botão esquerdo</Button>
        <Button DockPanel.Dock="Right">Botão direito</Button>
        <Button>Espaço restante</Button>
    </DockPanel>
 ```

 ![SimpleDockPanel](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/18.png)
 
 ### Layout containers e seus alinhamentos
 
O StackPanel, WrapPanel e DockPanel raramente são usados por conta própria. Em vez disso, eles são usados para moldar partes de sua interface. Por exemplo, você pode usar um DockPanel para colocar diferentes StackPanel e Contêineres WrapPanel nas regiões apropriadas de uma janela.
Por exemplo, imagine que você deseja criar uma caixa de diálogo padrão com um botão OK e Cancelar no canto inferior direito e uma grande região de conteúdo no resto da janela. Você pode modelar esta interface com WPF de várias maneiras, mas a opção mais fácil que usa os painéis que você viu até agora é a seguinte:

```
<DockPanel LastChildFill="True">
        <StackPanel DockPanel.Dock="Bottom" HorizontalAlignment="Right" Orientation="Horizontal">
            <Button Margin="10,10,2,10" Padding="3">OK</Button>
            <Button Margin="2,10,10,10" Padding="3">Cancelar</Button>
        </StackPanel>
        <TextBox DockPanel.Dock="Top" Margin="10">Isto é um teste.</TextBox>
 </DockPanel>
```

Percebam que o **TextBox** vai por último justamente para ocupar todo o espaço restante como demonstrado nos exemplos anteriores.

![BasicDialogBox](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/19.png)

## O Grid

<p>
O Grid é o contêiner de layout mais poderoso do WPF. Muito do que você pode realizar com o outro controles de layout também são possíveis com a grade. A grade também é uma ferramenta ideal para esculpir sua janela em regiões menores que você pode gerenciar com outros painéis. Na verdade, a grade é tão útil que quando você adiciona um
novo documento XAML para uma janela no Visual Studio, ele adiciona automaticamente as tags Grid como o primeiro nível container, alinhado dentro do elemento Window raiz.
</p>

<p>
A grade separa os elementos em uma grade invisível de linhas e colunas embora mais de uma elemento pode ser colocado em uma única célula (nesse caso, eles se sobrepõem), geralmente faz sentido colocar apenas um único elemento por célula. Claro, esse elemento pode ser outro contêiner(DockPanel, WrapPanel e StackPanel) de layout que organiza seu próprio grupo de controles contidos.
</p>

**Dica** : Embora o Grid seja projetado para ser invisível, você pode definir a propriedade **Grid.ShowGridLines** como true para obter um olhar mais de perto. Este recurso não se destina realmente a embelezar uma janela. Em vez disso, é uma conveniência de depuração que é projetado para ajudá-lo a entender como a grade se subdividiu em regiões menores. Este recurso é importante porque você tem a capacidade de controlar exatamente como a grade escolhe as larguras das colunas e as alturas das linhas.

```
<Grid ShowGridLines="True">
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition></ColumnDefinition>
            <ColumnDefinition></ColumnDefinition>
            <ColumnDefinition></ColumnDefinition>
        </Grid.ColumnDefinitions>

        <Button Grid.Row="0" Grid.Column="0">Esquerda superior</Button>
        <Button Grid.Row="0" Grid.Column="1">Meio Esquerdo</Button>
        <Button Grid.Row="1" Grid.Column="2">Direita inferior</Button>
        <Button Grid.Row="1" Grid.Column="1">Meio inferior</Button>
 </Grid>
```

![SimpleGrid](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/20.png)


**Nota** : A grade ajusta elementos em linhas e colunas predefinidas. Isso é diferente de contêineres de layout, como o WrapPanel e o StackPanel que criam linhas ou colunas implícitas à medida que organizam seus filhos. Se você quiser criar uma grade que tenha mais de uma linha e uma coluna, você deve definir suas linhas e colunas explicitamente usando objetos RowDefinition e ColumnDefinition.

### Usando o GRID no Visual Studio

<p>
Quando você usa uma grade na superfície de design do Visual Studio, você descobrirá que ela funciona de maneira um pouco diferente das outros recipientes e containêres de layout. À medida que você arrasta um elemento para uma grade, o Visual Studio permite que você o coloque em um local preciso. 
O Visual Studio faz essa mágica definindo a propriedade Margin do seu elemento.
</p>

<p>
Ao definir as margens, o Visual Studio usa o canto mais próximo. Por exemplo, se o seu elemento estiver mais próximo do canto superior esquerdo da grade, o Visual Studio preenche as margens superior e esquerda para posicionar o elemento (e deixa o margens direita e inferior em 0). Se você arrastar seu elemento para baixo mais perto do canto inferior esquerdo, o Visual Studio define as margens inferior e esquerda em vez disso e define a propriedade VerticalAlignment como Bottom. Isso obviamente afeta como o elemento se moverá quando a grade for redimensionada.
 </p>
 
 <p>
O processo de definição de margem do Visual Studio parece bastante direto, mas na maioria das vezes ele não cria os resultados que você deseja. Normalmente, você desejará um layout de fluxo mais flexível que permita que alguns elementos se expandam dinamicamente e empurre os outros para fora do caminho. Neste cenário, você descobrirá que codificar uma posição com a propriedade da margem é extremamente inflexível. 
 </p>
 
 <p>
Os problemas pioram quando você adiciona vários elementos, porque O Visual Studio não adiciona novas células automaticamente. Como resultado, todos os elementos serão colocados na mesma célula. Diferentes elementos podem ser alinhados a diferentes cantos da grade, o que fará com que eles se movam com relação um ao outro (e até mesmo se sobrepõem) conforme a janela é redimensionada.
 </p>
 
 <p>
Depois de entender como funciona o Grid, você pode corrigir esses problemas. O primeiro truque é configurar sua Grade antes de começar a adicionar elementos, definindo suas linhas e colunas. (Você pode editar o RowDefinitions e coleções ColumnDefinitions usando a janela Propriedades.) Depois de configurar o Grid, você pode arrastar e soltar os elementos que você deseja na grade e definir suas configurações de margem e alinhamento na janela de propriedades ou editando o XAML manualmente.
 </p>
 
 ### Ajuste finos de linhas e colunas
 
 O Grid oferece suporte a três estratégias de dimensionamento:
 
 - ***Tamanhos absolutos*** : você escolhe o tamanho exato usando unidades independentes de dispositivo. Essa é a estratégia menos útil porque não é flexível o suficiente para lidar com mudanças de tamanho do conteúdo, alteração do tamanho do contêiner ou localização.
 
 - ***Tamanhos automáticos*** : cada linha ou coluna recebe exatamente a quantidade de espaço que possui de acordo com suas necessidades, e nada mais. Este é um dos modos de dimensionamento mais úteis.
 
 - ***Tamanhos proporcionais*** : o espaço é dividido entre um grupo de linhas ou colunas. Isto é a configuração padrão para todas as linhas e colunas. Por exemplo veja que todas as células aumentam de tamanho proporcionalmente à medida que a grade se expande em uma janela. 


Para obter o máximo de flexibilidade, você pode misturar e combinar esses modos de dimensionamento. Por exemplo, muitas vezes é útil criar várias linhas de tamanho automático e deixar uma ou duas linhas restantes obter o espaço restante através do dimensionamento proporcional.
Você define o modo de dimensionamento usando a propriedade Width do objeto ColumnDefinition ou a propriedade Height do objeto RowDefinition. Por exemplo, aqui está como você define uma largura absoluta de 100 unidades independentes do dispositivo:

```
<ColumnDefinition Width = "100"> </ColumnDefinition>
```

Para usar o dimensionamento automático, você usa um valor de Auto:

```
<ColumnDefinition Width = "Auto"> </ColumnDefinition>
```

Finalmente, para usar o dimensionamento proporcional, você usa um asterisco (*):

```
<ColumnDefinition Width = "*"> </ColumnDefinition>
```

Se você usar uma combinação de dimensionamento proporcional e outros modos de dimensionamento, as linhas de tamanho proporcional ou colunas obtêm todo o espaço que sobra.
Se você quiser dividir o espaço restante de forma desigual, você pode atribuir um peso que você deve colocar antes do asterisco. Por exemplo, se você tiver duas linhas de tamanho proporcional e quiser que a primeira seja metade da altura da segunda, você poderia compartilhar o espaço restante assim:
```
<RowDefinition Height = "*"> </RowDefinition>
<RowDefinition Height = "2 *"> </RowDefinition>
```
Isso informa ao Grid que a altura da segunda linha deve ser duas vezes a altura da primeira linha. Você pode usar os números que desejar para distribuir o espaço extra.

```
<Grid ShowGridLines="True">
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>
        <TextBox Margin="10" Grid.Row="0">Isto é um teste.</TextBox>
        <StackPanel Grid.Row="1" HorizontalAlignment="Right" Orientation="Horizontal">
            <Button Margin="10,10,2,10" Padding="3">OK</Button>
            <Button Margin="2,10,10,10" Padding="3">Cancelar</Button>
        </StackPanel>
</Grid>
```

***Dica*** : Esta grade não declara nenhuma coluna. Este é um atalho que você pode usar se sua grade usar apenas uma coluna e essa coluna é dimensionada proporcionalmente (portanto, preenche toda a largura da grade).

![DialogBox](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/21.png)
