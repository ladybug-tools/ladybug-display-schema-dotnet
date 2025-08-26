.PHONY: sdk

NEW_RELEASE_VERSION ?= 0.0.1
download:
	cd ./.generator/SchemaGenerator && dotnet run --download --updateVersion

sdk:
	cd ./.generator/SchemaGenerator && dotnet run --download --genCsModel --genCsInterface --updateVersion

build:
	make cs-build

test:
	make cs-test

cs-sdk:
	cd ./.generator/SchemaGenerator && dotnet run --genCsModel --genCsInterface --updateVersion

cs-build:
	cd ./src/CSharpSDK && dotnet build

cs-test:
	cd ./src/CSharpSDK.Tests && dotnet test
