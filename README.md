# TesteFullStackKonatus1
O SISTEMA DE MANUTENÇÃO DE AERONAVES é um teste criado pela Konatus para avaliar o nível de habilidade de desenvolvedores full stack. 
Nele, o candidato deverá criar sua própria API e front-end.
BACK-END
As rotas que deverão ser criadas:
• Autenticação
• Listagem de manutenções
• Criação de um registro de manutenção
• Listagem de etapas
• Execução de uma etapa

FRONT-END

REQUISITOS DO TESTE
O comportamento do sistema deverá ser composto pela
• Autenticação
o Utilizar token JWT
• Exibição e manipulação de listas
• Exibição e manipulação de inputs de usuário
• Validação de formulários e de rotas de navegação

1. LOGIN
2. LISTA DE MANUTENÇÕES DO USUÁRIO
3. CRIAR UMA MANUTENÇÃO
4. LISTA DE ETAPAS DA MANUTENÇÃO
5. EXECUÇÃO DA ETAPA

BANCO DE DADOS
Tabela 1 – Users (USUÁRIOS)
• Id – unique identifier – GUID – NOT NULL – PRIMARY KEY
• Login – VARCHAR – NOT NULL
• Password – VARCHAR – NOT NULL
• CreatedAt – DATETIME – NOT NULL

Tabela 2 – Maintenance (MANUTENÇÕES)
• Id – unique identifier – GUID – NOT NULL – PRIMARY KEY
• UserId – unique identifier – GUID – NOT NULL – FK Users(Id)
• Description – VARCHAR – NOT NULL
• Status – Boolean / Bit – NOT NULL
o Valor: 0 – Manutenção em execução
o Valor: 1 – Manutenção finalizada
• CreatedAt – DATETIME – NOT NULL

Tabela 3 – Stage (ETAPAS)
• Id – unique identifier – GUID – NOT NULL – PRIMARY KEY
• MaintenanceId – unique identifier – GUID – NOT NULL – FK Maintenance(Id)
• Description – VARCHAR – NOT NULL
• Status – Boolean / Bit – NOT NULL
o Valor: 0 – Etapa em execução
o Valor: 1 – Etapa finalizada
• Type – Int – NOT NULL
o Valor: 1 – Etapa de texto
o Valor: 2 – Etapa de número
o Valor: 3 – Etapa de foto
• Value – VARCHAR – NOT NULL (Deverá ser preenchido com o conteúdo de texto,
número ou foto)
• CreatedAt – DATETIME – NOT NULL
