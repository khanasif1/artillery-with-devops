from hashlib import new
from logging import root
from aws_cdk import (
    Stack,
    aws_lambda as _lambda,
    aws_apigateway as apigw,
    aws_iam as iam
)
from constructs import Construct

class ApiStack(Stack):

    def __init__(self, scope: Construct, construct_id: str, **kwargs) -> None:
        super().__init__(scope, construct_id, **kwargs)

        # The code that defines your stack goes here
        lambdaApi = _lambda.Function(
            self, 'getItemDetailsAPI',
            runtime=_lambda.Runtime.PYTHON_3_7,
            code=_lambda.Code.from_asset('lambda'),
            handler='getItems.handler',
        )
        principal = iam.ServicePrincipal("apigateway.amazonaws.com") 
        lambdaApi.grant_invoke(principal)

        dev_deployment = apigw.StageOptions(
            stage_name="dev",
            variables={
                "lambdaAlias":"dev"
            }
        )
        api = apigw.LambdaRestApi(
            self,"getItemsApiendpoint",
            handler=lambdaApi,
            deploy_options=dev_deployment,
            endpoint_types=[apigw.EndpointType.REGIONAL]
            
        )