
Feature: Valid Journey 

Background: 
	Given the user is on the journey planner page
	Given the user accepts the cookie prompt

	@valid
Scenario Outline: (Q1) User can plan a valid journey using the widget
	Given the user provides a valid "<source>" and "<destination>"
	When the user submits the journey
	Then the user is taken to the "Journey results" page
	Examples:
	| source					  | destination | 
	| East Croydon Train Station  | North Grenwhich Underground Station   |

	@invalid
Scenario Outline: (Q2)  User cannot plan a journey with invalid start and destination
	Given the user provides an invalid "<source>" and invalid "<destination>"
	When the user submits the journey
	Then the user is taken to the "Journey results" page
	And an error "<message>" is displayed on the page
	Examples:
	| source    | destination | message																		 |
	| £$%&*@()# | £$%&*@()#   |  Journey planner could not find any results to your search. Please try again |

	@invalid
Scenario Outline:  (Q3)  User cannot plan a journey with missing start and destination
	Given the user provides an invalid "<source>" and invalid "<destination>"
	When the user submits the journey
	Then a validation error is displayed for the missing source
	And a validation error is displayed for the missing destination
	Examples:
	| source    | destination | 
	|		    |			  |	 

	@valid
Scenario Outline: (Q4)  User can plan a valid journey based on an arrival time
	Given the user provides a valid "<source>" and "<destination>"
	And the user provides an arrival "<time>"
	When the user submits the journey
	Then the user is taken to the "Journey results" page
	Examples:
	| source                     | destination                         | time |  
	| East Croydon Train Station | North Grenwhich Underground Station | 2345 |

Scenario Outline: (Q5)  User can edit a planned journey
	Given the user provides a valid "<source>" and "<destination>"
	When the user submits the journey
	Then the user is taken to the "Journey results" page
	And the user can edit the journey
	And the user is taken to the "Journey results" page
	Examples:
	| source					  | destination | 
	| East Croydon Train Station  | North Grenwhich Underground Station   |

	Scenario Outline: (Q6)  User can use the recents tab to display a list of recent journeys
	#Given the user provides a valid "<source>" and "<destination>"
	And the user selects the recent tab
	Examples:
	| source					  | destination | 
	| East Croydon Train Station  | North Grenwhich Underground Station   |

