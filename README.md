# PeGi
PeGi - Pequenas Economias Grandes Investimentos

# Instruções para executar o projeto localmente

# Instalações Necessárias

- Instale o Microsoft Visual Studio Community 2019
- Instale a SDK .Net Framework 4.7.2
- Instale o SQL Server
- Instale o SQL Server Management Studio

# Criação do Banco

- Crie um banco no Management Studio (CREATE DATABASE pegi)
- Abra a pasta DatabaseScripts e execute as queries na sequência: ModeloFisicoPegi.sql, InsertsNecessarios.sql

# Execução

- Abra o Visual Studio, selecine o menu Ferramentas e conecte-se ao banco criado
- Abra o Gerenciador de servidores, selecione o banco, clique em propriedades e copie a cadeia de de conexão (connection string)
- Abra a classe DBSession e cole a connection string na propriedade da instância de SqlConnection dentro do construtor do DBSession
- Compile e execute o projeto normalmente

