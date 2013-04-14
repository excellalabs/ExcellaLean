@AAT
Feature: Request ReportA
	As a user
	I want to request a ReportA
	so that I can review it before creating option forms

Scenario: Requesting a ReportA
	Given I log into ModuleA as a Registered User Tim with role SuperUser
	  And I view a record
	When I click the Request ReportA link
	Then I see that a ReportA has been requested
