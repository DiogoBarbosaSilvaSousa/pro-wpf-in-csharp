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

<p>
**Dica** : Pense duas vezes antes de definir um tamanho explícito no WPF. Em um layout bem projetado, não deve ser necessário. Se você
adicionar informações de tamanho, você corre o risco de criar um layout mais frágil que não pode se adaptar às mudanças (como
idiomas e tamanhos de janela) e trunca seu conteúdo.
 </p>

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
