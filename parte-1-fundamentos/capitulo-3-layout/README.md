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

Essa marcação é um pouco mais longa, mas tem a vantagem de declarar os controles na ordem em que devem aparecer, o que torna mais fácil de entender. Neste caso, a abordagem que você adota é simplesmente uma questão de preferência. E se quiser, você pode substituir o StackPanel por uma Grid de uma linha e duas colunas.

***Nota*** : Você pode criar quase qualquer interface usando contêineres Grid aninhados (Um Grid dentro do outro). (Uma exceção são linhas quebradas ou colunas que usam o WrapPanel.) No entanto, quando você está lidando com pequenas seções da interface do usuário ou criando um pequeno número de elementos, muitas vezes é mais simples usar os contêineres StackPanel e DockPanel mais especializados e simples de usar.

### Arredondamento de Layout (Problemas com o arredondamento no cálculo da divisão do Layout)
<p>
O WPF usa um sistema de medição que é independente de resolução. Isso permite uma flexibilidade enorme ao trabalhar com uma variedade de hardwares mas às vezes apresenta suas próprias peculiaridades em alguns casos. Um exemplo é uma coordenada na divisão de um determinado pixel pode não se alinhar perfeitamente ao pixel físico de uma tela.
</p>

<p>
Imagine que você tem um Grid de duas colunas e 200 pixels para trabalhar(dividir) entre essas duas geralmente isso não é um problema afinal são 100 pixels para cada coluna se você distribuir igualmente mas se você tiver uma grade com 175 pixels essa não vai ser uma divisão "limpa" pois cada coluna deveria ter 87,5 pixels. Isso basicamente significa que a segunda coluna vai está ligeiramente deslocada dos limites do pixel comuns.
</p>

<p>
Na maior parte dos casos isso pode não ser um problema mas se você tiver algum elemento, figura ou borda justamente próximo deste canto específico o conteúdo pode parecer borrado porque o WPF usa anti-aliasing para "mesclar".
</p>

Se esse problema afetar seu layout, há uma solução fácil. Basta definir a propriedade ***UseLayoutRounding*** como true em seu contêiner de layout:

```
<Grid UseLayoutRounding = "True">
```

Agora o WPF irá garantir que todo o conteúdo nesse recipiente(container) do layout seja ajustado ao pixel mais próximo do limite, removendo qualquer borrão.


### Spanning Rows and Columns (Abrangendo ou "mesclando" mais de uma coluna ou linha)

Você já viu como colocar elementos em células usando as propriedades anexadas de Linha e Coluna. Vocês também podem usar mais duas propriedades anexadas para fazer um elemento se estender por várias células: RowSpan e ColumnSpan. Essas propriedades pegam o número de linhas ou colunas que o elemento deve ocupar. 

Por exemplo, este botão ocupará todo o espaço disponível na primeira e na segunda célula do primeira e segunda linha na fileira da primeira coluna:

```
<Button Grid.Row="0" Grid.Column="0" Grid.RowSpan="2">Botão Span</Button>
```

E este botão se estenderá por quatro células no total, abrangendo duas colunas e duas linhas:

```
<Button Grid.Row="0" Grid.Column="0" Grid.RowSpan="2" Grid.ColumnSpan="2">Botão Span</Button>
```

A mesclagem de linha e coluna pode alcançar alguns efeitos interessantes e é particularmente útil quando você precisa encaixar elementos em uma estrutura tabular que é dividida por divisórias ou seções mais longas de conteúdo.
Usando a mesclagem de coluna, você pode reescrever o exemplo da caixa de diálogo simples da usando apenas uma única grade. Esta grade divide a janela em três colunas, espalha a caixa de texto por todas as três, e usa as duas últimas colunas para alinhar os botões OK e Cancelar.

```
<Grid ShowGridLines="True">
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"></ColumnDefinition>
            <ColumnDefinition Width="Auto"></ColumnDefinition>
            <ColumnDefinition Width="Auto"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <TextBox Margin="10" Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="3">
            Isto é um teste.
        </TextBox>
        <Button Margin="10,10,2,10" Padding="3" Grid.Row="1" Grid.Column="1">OK</Button>
        <Button Margin="2,10,10,10" Padding="3" Grid.Row="1" Grid.Column="2">Cancelar</Button>
</Grid>
```

![DialogBox](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/22.png)

***Observação***
> Caso ainda não tenham percebido a primeira coluna ou linha começa a partir do número 0, o número 1 seria a segunda linha ou coluna a contagem de linhas e colunas segue o mesmo padrão de contagem usado em um Array (vetor) que começa a partir do Zero (0) e não do número 1 (um) como estamos acostumados a contar no dia a dia. 

***Atenção***
>A maioria dos desenvolvedores concordará que este layout não é claro ou sensato. As larguras das colunas são determinadas pelo tamanho dos dois botões na parte inferior da janela, o que torna difícil adicionar novo conteúdo na estrutura de grade existente. Se você fizer uma pequena adição a esta janela, provavelmente será forçado a criar um novo conjunto de colunas.

>Quando você escolhe os contêineres de layout para uma janela, você não está simplesmente interessado em obter o comportamento de layout correto - você também deseja construir uma estrutura de layout que seja fácil de manter e melhorar no futuro. Uma boa regra é usar contêineres de layout menores, como o StackPanel para tarefas de layout únicas, como organizar um grupo de botões. Por outro lado, se você precisar aplicar um estrutura consistente para mais de uma área de sua janela (como com a coluna da caixa de texto mostrada mais adiante, o Grid é uma ferramenta indispensável para padronizar seu layout). 

>Logo o ideal é sempre uma combinação inteligente dos containêres disponíveis Grid, DockerPanel e StackPanel para facilitar a manutenção do seu layout. Lembrando que não é obrigatório usar os três ao mesmo tempo mas é interessante que cada um deles resolve um determinado problema de uma forma diferente que pode facilitar e muito na diagramação da sua aplicação WPF.

### Splitting Windows (Divisão de Janelas)

Cada usuário do Windows viu já barras divisórias - divisórias arrastáveis que separam uma seção de uma janela da outra. Por exemplo, quando você usa o Windows Explorer, é apresentada uma lista de pastas (à esquerda) e uma lista de arquivos (à direita). Você pode arrastar a barra divisora para determinar a proporção da janela fornecida para cada painel.

No WPF, as barras divisórias são representadas pela classe GridSplitter e são um recurso do Grid. Adicionando um GridSplitter para uma grade, você dá ao usuário a capacidade de redimensionar linhas ou colunas. Ao arrastar a barra divisora, o usuário pode alterar as larguras de ambas as colunas.

```
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition MinWidth="100"></ColumnDefinition>
            <!-- Nesta coluna ficará um GridSplitter por isso uso o tamanho Auto pois quero uma largura mínima -->
            <ColumnDefinition Width="Auto"></ColumnDefinition>
            <ColumnDefinition MinWidth="50"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <Button Grid.Row="0" Grid.Column="0" Margin="3">Esquerda</Button>
        <Button Grid.Row="0" Grid.Column="2" Margin="3">Direita</Button>
        <Button Grid.Row="2" Grid.Column="0" Margin="3">Esquerda</Button>
        <Button Grid.Row="2" Grid.Column="2" Margin="3">Direita</Button>

        <!-- Esse divisor fica na coluna do centro (segunda coluna) ocupando o espaço de três linhas -->
        <GridSplitter Grid.Row="0" Grid.Column="1" Grid.RowSpan="3"  Width="3" VerticalAlignment="Stretch" 
                      HorizontalAlignment="Center" ShowsPreview="False"></GridSplitter>
    </Grid>
```

![SplitWindow](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/23.png)

```
   <Grid>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <!-- Nesta linha ficará um GridSplitter por isso uso o tamanho Auto pois quero uma altura mínima -->
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition MinWidth="100"></ColumnDefinition>
            <!-- Nesta coluna ficará um GridSplitter por isso uso o tamanho Auto pois quero uma largura mínima -->
            <ColumnDefinition Width="Auto"></ColumnDefinition>
            <ColumnDefinition MinWidth="50"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <Button Grid.Row="0" Grid.Column="0" Margin="3">Esquerda</Button>
        <Button Grid.Row="0" Grid.Column="2" Margin="3">Direita</Button>
        <Button Grid.Row="2" Grid.Column="0" Margin="3">Esquerda</Button>
        <Button Grid.Row="2" Grid.Column="2" Margin="3">Direita</Button>

        <!-- Esse divisor fica na coluna do centro (segunda coluna) ocupando o espaço de três linhas -->
        <GridSplitter Grid.Row="0" Grid.Column="1" Grid.RowSpan="3"  Width="3" VerticalAlignment="Stretch" 
                      HorizontalAlignment="Center" ShowsPreview="False"></GridSplitter>
        
        <!-- Esse divisor fica na linha do meio (segunda linha) ocupando o espaço de três colunas -->
        <GridSplitter Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="3" Height="3" HorizontalAlignment="Stretch" 
                      VerticalAlignment="Center" ShowsPreview="False"></GridSplitter>
    </Grid>
```

![SplitWindow](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/25.png)

Criar esta janela é bastante simples, embora seja uma tarefa de manter o controle dos três Grid (contêineres) que estão envolvidos: a grade geral, a grade alinhada à esquerda e a grade alinhada à direita. O único truque é garantir que o GridSplitter seja colocado na célula correta e tenha o alinhamento correto. Aqui está a marcação completa:

```
<Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition></ColumnDefinition>
            <!-- Nesta coluna ficará um GridSplitter por isso uso o tamanho Auto pois quero uma largura mínima -->
            <ColumnDefinition Width="Auto"></ColumnDefinition>
            <ColumnDefinition></ColumnDefinition>
        </Grid.ColumnDefinitions>
        
        <!-- (Primeira coluna "0" )Esta é a grade alinhada à esquerda. Não é subdividida com um divisor. -->
        <Grid Grid.Column="0" VerticalAlignment="Stretch">
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <Button Margin="3" Grid.Row="0">Superior Esquerdo</Button>
            <Button Margin="3" Grid.Row="1">Infeior Esquerdo</Button>
        </Grid>
        
        <!-- (Segunda coluna "1") Este é o divisor vertical que fica entre as duas grades alinhadas (esquerda e direita). -->
        <GridSplitter Grid.Column="1" Width="3" HorizontalAlignment="Center" VerticalAlignment="Stretch"  ShowsPreview="False"></GridSplitter>
       
        <!-- (Terceira coluna "2") Esta é a grade alinhada à direita. -->
        <Grid Grid.Column="2">
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <!-- Nesta linha ficará um GridSplitter por isso uso o tamanho Auto pois quero uma altura mínima -->
                <RowDefinition Height="Auto"></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <Button Grid.Row="0" Margin="3">Superior Direito</Button>
            <Button Grid.Row="2" Margin="3">Inferior Direito</Button>
            
            <!-- Este é o divisor horizontal que o subdivide em uma região superior e inferior no lado direito. -->
            <GridSplitter Grid.Row="1" Height="3" VerticalAlignment="Center" HorizontalAlignment="Stretch" ShowsPreview="False"></GridSplitter>
        </Grid>
 </Grid>
```

![DoubleSplitWindow](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/24.png)

***Dica*** : Lembre-se, se uma grade tiver apenas uma única linha ou coluna, você pode deixar de fora a seção RowDefinitions. Elementos que não têm sua posição de linha explicitamente definida são considerados como tendo um valor Grid.Row de 0 e são colocados na primeira linha. O mesmo vale para elementos que não fornecem um valor Grid.Column.

### Grupos de tamanhos compartilhados (Shared Size Groups)

Imagine que você tem dois ou mais grupos de Grid em seu painel, normamelnte o comportamento deles é independente um do outro mas imagine que você tenha um conteúdo numa determinada linha ou coluna em um dos Grids e quer que uma linha ou coluna num outro Grid se comporte tendo o mesmo tamanho como fazer esse redimensionamento ? Neste caso usamos a propriedade ***SharedSizeGroup*** e atribuímos um nome para ela no exemplo abaixo eu atribui a propriedade a duas colunas (SharedSizeGroup="TextLabel") que agora trabalham como se fosse uma respeitando aquela que possui maior conteúdo. Lembrando que pelo menos uma das linhas ou colunas precisam está como Width="Auto" ou Height="Auto" preferencialmente as duas colunas ou linhas deven ser definidas como "Auto". 

***Caso não tenha ficado claro o motivo de pelo menos um deles ter que está com o tamanho definido como Auto é que se tornaria inútil usar essa propriedade ***SharedSizeGroup*** se os valores forem absolutos, uma vez que o objetivo é redimensionar o tamanho dinamicamente.*** 

```
    <Grid Grid.IsSharedSizeScope="True" Margin="3">
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>

        <Grid Grid.Row="0" Margin="3" Background="LightYellow" ShowGridLines="True">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" SharedSizeGroup="TextLabel"></ColumnDefinition>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Label Margin="5">Um texto muito longo</Label>
            <Label Grid.Column="1" Margin="5">Mais texto</Label>
            <TextBox Grid.Column="2" Margin="5">Uma caixa de texto</TextBox>
        </Grid>

        <Label Grid.Row="1" >Algum texto entre as duas grades ...</Label>

        <Grid Grid.Row="2" Margin="3" Background="LightYellow" ShowGridLines="True">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" SharedSizeGroup="TextLabel"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Label Margin="5">Curto</Label>
            <TextBox Grid.Column="1" Margin="5">Uma caixa de texto</TextBox>
        </Grid>

    </Grid>
```

![SharedSizeGroup](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/26.png)

**Dica** : Você pode usar um grupo de tamanho compartilhado para sincronizar uma grade separada com cabeçalhos (colunas). A largura de cada coluna pode então ser determinada pelo conteúdo da coluna que o cabeçalho irá compartilhar. Você pode até colocar um GridSplitter no cabeçalho para que o usuário possa redimensionar o cabeçalho e toda a coluna abaixo simplestemente arrastando para os lados.

## O UniformGrid

O UniformGrid é usado com muito menos frequência do que o Grid. O Grid é uma ferramenta multifuncional para criar layouts de janela do simples ao complexo. O UniformGrid é um layout muito mais especializado que é principalmente útil ao dispor rapidamente os elementos em uma grade rígida (por exemplo, quando construir um tabuleiro de jogo para certos jogos). Muitos programadores de WPF nunca usarão o UniformGrid. (Na verdade eu nem mesmo achei na versão do Visual Studio 2019 o UniformGrid na ToolBox junto com os outros componentes, literalmente você precisa digitar se quiser usar.)

```
<UniformGrid Rows="2" Columns="2">
        <Button>Esquerda Superior</Button>
        <Button>Direita Superior</Button>
        <Button>Esquerda Inferior</Button>
        <Button>Direita Inferior</Button>
</UniformGrid>
```
![SimpleUniformGrid](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/27.png)

## Layout baseado em coordenadas na tela (Canvas)

O único contêiner de layout quê ainda não consideramos é o Canvas. Ele permite que você coloque elementos usando coordenadas exatas, que é uma escolha ruim para projetar formulários baseados em dados ricos e caixas de diálogo padrão, mas uma ferramenta valiosa se você precisar construir algo um pouco diferente (como uma superfície de desenho para uma ferramenta de diagramação). 

O Canvas também é o mais leve dos contêineres de layout. Isso é porque não inclui nenhuma lógica de layout complexa para negociar as preferências de tamanho de seus filhos. Em vez disso simplesmente os coloca na posição que especificam, com o tamanho exato que desejam. Para posicionar um elemento no Canvas você define as propriedades Canvas.Left e Canvas.Top anexadas. Canvas.Left define o número de unidades entre a borda esquerda do seu elemento e a borda esquerda do Canvas. Canvas.Top define o número de unidades entre o topo do seu elemento e o topo do Canvas. Como sempre, esses valores são definidos em unidades independentes de dispositivo, que se alinham com pixels comuns exatamente quando
o DPI do sistema é definido como 96 dpi.

Como alternativa, você pode usar Canvas.Right em vez de Canvas.Left para espaçar um elemento da borda direita do Canvas e o Canvas.Bottom em vez de Canvas.Top para espaçá-lo a partir da parte inferior. Você simplesmente não pode usar o Canvas.Right e Canvas.Left de uma vez, ou Canvas.Top e Canvas.Bottom.

Opcionalmente, você pode dimensionar seu elemento explicitamente usando suas propriedades Width e Height. Isso é mais comum ao usar o Canvas do que em outros painéis porque o Canvas não tem lógica de layout. (Muitas vezes você usará o Canvas quando precisar de controle preciso sobre como uma combinação de elementos é organizado.) Se você não definir as propriedades Width e Height, seu elemento terá o tamanho desejado - em em outras palavras, ele crescerá apenas o suficiente para caber em seu conteúdo.

Aqui está uma tela simples que inclui quatro botões:

```
<Canvas>
        <Button Canvas.Left="10" Canvas.Top="10">(10,10)</Button>
        <Button Canvas.Left="120" Canvas.Top="30">(120,30)</Button>
        <Button Canvas.Left="60" Canvas.Top="80" Width="50" Height="50">
            (60,80)</Button>
        <Button Canvas.Left="70" Canvas.Top="120" Width="100" Height="50">
            (70,120)</Button>
</Canvas>
```

![LayoutPanelsCanvas](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/28.png)

Se você redimensionar a janela o Canvas se estende para preencher o espaço disponível, mas nenhum dos controles na tela se move ou muda de tamanho. O Canvas não inclui nenhum dos recursos de ancoragem ou encaixe que foram fornecidos com o layout de coordenadas no Windows Forms. Parte da razão para essa lacuna é manter o Canvas leve. Outro motivo é evitar que as pessoas usem o Canvas para os fins nos quais ele não é pretendido (como o layout de uma interface de usuário padrão).
Como qualquer outro contêiner de layout, o Canvas pode ser alinhado dentro de uma interface de usuário. Isso significa que você pode usar o Canvas para desenhar algum conteúdo detalhado em uma parte de sua janela, usando mais padrões de painéis WPF para o resto de seus elementos (Grid, DockPanel e StackPanel).

### Z-Order (Ordenação no eixo Z)

Se você tiver mais de um elemento sobreposto, pode definir a propriedade Canvas.ZIndex anexada para controlar como eles são dispostos em camadas.
Normalmente, todos os elementos que você adiciona têm o mesmo ZIndex — 0. Quando os elementos têm o mesmo ZIndex, eles são exibidos na mesma ordem em que existem na coleção Canvas.Children, que é baseada na marcação definida no XAML. Elementos declarados posteriormente na marcação, como o botão (70,120) - são exibidos na parte superior dos elementos declarados anteriormente - como o botão (120,30).

No entanto, você pode promover qualquer elemento a um nível superior aumentando seu ZIndex. Isso é porque os elementos ZIndex superiores sempre aparecem sobre os elementos ZIndex inferiores. Usando esta técnica, você poderia inverta a estratificação no exemplo anterior:


```
<Canvas>
        <Button Canvas.Left="10" Canvas.Top="10">(10,10)</Button>
        <Button Canvas.Left="120" Canvas.Top="30">(120,30)</Button>
        <Button Canvas.Left="60" Canvas.Top="80" Canvas.ZIndex="1" Width="50" Height="50">
         (60,80)</Button>
        <Button Canvas.Left="70" Canvas.Top="120" Width="100" Height="50">
         (70,120)</Button>
</Canvas>
```

![LayoutPanelsCanvas](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/29.png)

***Nota*** 
> Os valores que você usa para a propriedade Canvas.ZIndex não têm significado. O detalhe importante é como o O valor ZIndex de um elemento se compara ao valor ZIndex de outro. Você pode definir o ZIndex usando qualquer número inteiro positivo ou negativo.

A propriedade ZIndex é particularmente útil se você precisar alterar a posição de um elemento programaticamente. Basta chamar Canvas.SetZIndex e passar o elemento que você deseja modificar e o novo ZIndex que você deseja aplicar. Infelizmente, não há método BringToFront() ou SendToBack() - depende de você acompanhar os valores ZIndex mais altos e mais baixos se quiser implementar esse comportamento.

## O InkCanvas

WPF também inclui um elemento InkCanvas que é semelhante ao Canvas em alguns aspectos (e totalmente diferente em outros). Como o Canvas, o InkCanvas define quatro propriedades anexadas às quais você pode aplicar elementos filhos para posicionamento baseado em coordenadas (superior, esquerda, inferior e direita). No entanto o código por trás dele é um pouco diferente - na verdade, o InkCanvas não deriva do Canvas ou mesmo da base classe Panel. Em vez disso, ele deriva diretamente de FrameworkElement.

O objetivo principal do InkCanvas é permitir a entrada da caneta. Uma caneta é um dispositivo de entrada semelhante a uma caneta que é usado em tablets e PCs. No entanto, o InkCanvas funciona com o mouse da mesma forma que funciona com a caneta. Assim um usuário pode desenhar linhas ou selecionar e manipular elementos no InkCanvas usando o mouse.
O InkCanvas contém duas coleções de conteúdo filho. A coleção Children que é arbitrária elementos, assim como com o Canvas. Cada elemento pode ser posicionado com base na parte superior, esquerda, inferior e Propriedades certas. A coleção Strokes contém objetos System.Windows.Ink.Stroke, que representam entrada gráfica que o usuário desenhou no InkCanvas. Cada linha ou curva que o usuário desenha se torna um objeto Stroke separado. Graças a essas coleções duplas, você pode usar o InkCanvas para permitir que o usuário anote conteúdo (armazenado na coleção Children) com traços (armazenado na coleção Strokes).

```
 <InkCanvas Name="inkCanvas" Background="LightYellow" EditingMode="Ink">
            <Image Source="/components/Images/the-fresh-prince-of-bel-air.jpg" 
                   InkCanvas.Top="60" InkCanvas.Left="20" Width="400" Height="350"/>
</InkCanvas>
```

![SimpleInkCanvas](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-3-layout/30.png)

- ***Ink*** O InkCanvas permite ao usuário fazer anotações. Este é o modo padrão. Quando o o usuário desenha com o mouse ou a caneta, um traço é desenhado.
- ***GestureOnly*** O InkCanvas não permite que o usuário desenhe anotações de traço, mas presta atenção a gestos predefinidos específicos (como arrastar a caneta em uma direção ou arranhar nosso conteúdo). A lista completa de gestos reconhecidos é listada pelo System.Windows.Ink. Enumeração de ApplicationGesture.
- ***InkAndGesture*** O InkCanvas permite que o usuário desenhe anotações de traço e também reconhece gestos predefinidos.
- ***EraseByStroke*** O InkCanvas apaga um traço quando é clicado. Um usuário pode mudar para este modo usando a extremidade posterior de uma caneta. (Você pode determinar o modo atual usando o modo somente leitura Propriedade ActiveEditingMode, e você pode alterar o modo usado para o back-end do stylus alterando a propriedade EditingModeInverted.)
- ***EraseByPoint*** O InkCanvas apaga uma parte de um traço (um ponto em um traço) quando essa parte é clicada. Selecionar O InkCanvas permite ao usuário selecionar os elementos que são armazenados no Filhos Children collection. Para selecionar um elemento, o usuário deve clicar nele ou arrastar um “laço” de seleção ao redor isto. Depois que um elemento é selecionado, ele pode ser movido, redimensionado ou excluído.
- ***None*** O InkCanvas ignora a entrada do mouse e da caneta.

