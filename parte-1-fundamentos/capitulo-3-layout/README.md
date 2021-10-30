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
