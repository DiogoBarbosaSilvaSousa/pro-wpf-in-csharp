# XAML

XAML (abreviação de Extensible Application Markup Language e zammel pronunciado) é uma linguagem de marcação
usado para instanciar objetos .NET. Embora o XAML seja uma tecnologia que pode ser aplicada a muitos problemas
domínios, seu papel principal na vida é construir interfaces de usuário WPF. Em outras palavras, documentos XAML
definem a disposição dos painéis, botões e controles que compõem as janelas em um aplicativo WPF.
É improvável que você escreva XAML manualmente. Em vez disso, você usará uma ferramenta que gera o XAML que você
precisar. Se você é um designer gráfico, essa ferramenta provavelmente será um programa de design gráfico como o Microsoft
Mistura de Expressão. Se você é um desenvolvedor, provavelmente começará com o Microsoft Visual Studio. Porque ambos
ferramentas estão igualmente em casa com o XAML, você pode criar uma interface de usuário básica com o Visual Studio e, em seguida,
entregá-lo a uma equipe de design de crack que pode poli-lo com gráficos personalizados no Expression Blend. Na verdade,
essa capacidade de integrar o fluxo de trabalho entre desenvolvedores e designers é uma das principais razões que
a Microsoft criou o XAML.

Este capítulo apresenta uma introdução detalhada ao XAML. Você considerará seu propósito, sua
arquitetura e sua sintaxe. Depois de entender as regras gerais do XAML, você saberá o que é e o que não é
possível em uma interface de usuário do WPF - e como fazer alterações manualmente quando necessário. Mais importante,
explorando as tags em um documento WPF XAML, você pode aprender um pouco sobre o modelo de objeto que sustenta
Interfaces de usuário do WPF e prepare-se para a exploração mais profunda que está por vir.

* O que há de novo - O WPF 4.5 não adiciona nada de novo ao padrão XAML. Na verdade, mesmo os pequenos refinamentos do XAML
2009 ainda não estão totalmente implementados. Eles são suportados apenas em arquivos XAML soltos, não em recursos XAML compilados (que
é o que praticamente todos os aplicativos WPF usam). Na verdade, o XAML 2009 provavelmente nunca se tornará uma parte totalmente integrada
do WPF, porque suas melhorias não são muito importantes, e qualquer alteração no compilador XAML aumenta a segurança e preocupações de desempenho. Por esse motivo, o XAML 2009 não é abordado neste livro.
