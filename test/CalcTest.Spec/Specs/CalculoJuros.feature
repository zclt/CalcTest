Feature: Calcula juros
	Calcular juros mensais com taxa fixa

@critical
Scenario: Informando o valor inicial e a quantidade de meses
	Given Um valor inicial 100.00
	And Uma quantidade de meses 5
	When Calcular o valor de juros
	Then O resultado deve ser 105.10
