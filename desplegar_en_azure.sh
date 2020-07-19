#oliverio@Azure:~$ az webapp deployment user set --user-name oliverio --password panama2020



az group create --name MiPhResourceGroup --location "East US"
az appservice plan create --name MiPhServicePlan --resource-group MiPhResourceGroup --sku F1 --is-linux
az webapp create --resource-group MiPhResourceGroup --plan MiPhServicePlan --name ByblosMiPruebaAPI --runtime "DOTNETCORE|3.1" --deployment-source-url "https://github.com/oliveriod/MiPrueba.git"



# Listar los perfiles para desplegar
az webapp deployment list-publishing-profiles --resource-group MiPhResourceGroup --name ByblosMiPruebaAPI


# 83ebf666-cd43-408b-9db1-cd5a8cc97876

#  Create a service principal and configure its access to Azure resources.
az ad sp create-for-rbac --name "MiPhUser" --role contributor --scopes /subscriptions/83ebf666-cd43-408b-9db1-cd5a8cc97876/resourceGroups/MiPhResourceGroup/providers/Microsoft.Web/sites/ByblosMiPruebaAPI --sdk-auth



az webapp deployment list-publishing-profiles \
  --query "[? publishMethod=='MSDeploy'] | [0]" \
  --resource-group "MiPhResourceGroup" \
  --name "MiPhUser"

