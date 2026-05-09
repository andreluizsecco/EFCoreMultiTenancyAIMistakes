## 📌 Sobre o Projeto

Este repositório é uma **prova de conceito (PoC)** super simples apresentada em um vídeo no canal, com o objetivo de demonstrar como a forma de construir prompts influencia diretamente no resultado gerado por inteligência artificial.

A proposta aqui é simples: mostrar, na prática, que **pequenas diferenças na construção de um prompt podem gerar impactos significativos na qualidade, segurança e comportamento do código gerado**.

Além disso, o projeto reforça um ponto crítico: **todo código gerado por IA deve passar por revisão**. A ausência desse cuidado pode introduzir problemas sérios, especialmente em cenários mais sensíveis.

---

## 🎯 Objetivo

Demonstrar:

- Como a engenharia de prompt impacta o resultado gerado por IA
- A importância de revisar o código após geração automatizada
- Problemas reais que podem surgir em aplicações SaaS mal projetadas
- Como evitar falhas comuns com pequenas melhorias no prompt

---

## 🧪 Caso de Uso

O cenário utilizado é uma aplicação **ASP.NET Core com suporte a multitenancy**, um contexto bastante comum em sistemas SaaS.

O foco principal da prova é um problema crítico e recorrente:

> ❗ **Vazamento de dados entre tenants (cross-tenant data leakage)**

Esse tipo de falha geralmente ocorre quando não há isolamento adequado dos dados, podendo comprometer completamente a segurança da aplicação.

---

## 🌿 Estrutura de Testes (Branches)

Os testes foram divididos em duas abordagens, disponíveis em branches diferentes:

### 🔹 [`Prompt1`](https://github.com/andreluizsecco/EFCoreMultiTenancyAIMistakes/tree/Prompt1)

- Prompt mais simples
- Pouco contexto
- Representa um cenário comum de quem não possui muito conhecimento técnico

**Resultado:**
A implementação gerada apresenta falhas, incluindo **vazamento de dados entre tenants**.

Isso acontece porque a IA não implementa corretamente o isolamento no contexto do Entity Framework Core, deixando brechas na filtragem de dados.

---

### 🔹 [`Prompt2`](https://github.com/andreluizsecco/EFCoreMultiTenancyAIMistakes/tree/Prompt2)

- Prompt ainda enxuto, porém mais estruturado
- Inclui detalhes técnicos específicos
- Direciona melhor a geração do código

**Resultado:**
A implementação já considera corretamente aspectos importantes, incluindo um detalhe específico no **DbContext do Entity Framework Core**, que garante o isolamento entre tenants.

Com isso, o problema de **cross-tenant leakage é evitado**.

OBS: Ainda assim está longe de ser um prompt ideal para esse tipo de construção

---

## 💡 Principal Insight

Não é necessário um prompt extremamente complexo para obter bons resultados.

➡️ **Pequenos ajustes e a inclusão de detalhes técnicos relevantes já são suficientes para evitar problemas críticos.**

---

## ⚠️ Observação Importante

Este repositório tem fins exclusivamente demonstrativos. Não deve ser seguido como referência, até porque foi gerado inteiramente com poucos prompts apenas para provar as hipóteses.

Existem diversas outras formas de garantir (ou reforçar) o isolamento entre tenants e evitar vazamento de dados, como por exemplo:

- Implementação de **Row-Level Security (RLS)** no banco de dados
- Estratégias de isolamento por schema ou database
- Middleware de validação de tenant
- Policies e filtros globais mais robustos
- Revisões manuais e testes de segurança

---
