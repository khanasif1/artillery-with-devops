import json
import requests


def handler(event, context):
    print('request: {}'.format(json.dumps(event)))  
    response = requests.get("http://api.open-notify.org/astros.json")
    print(response.json())
    d = {}
    i = 0;
    #BAD CODE
    # for i in range(0, 10000):
    # #for i in range(0, 10000):
    #   d[i] = 'A' * 1024
    # if i % 10000 == 0:
    #   print(i)   
    #BAD CODE  
    return {
        'statusCode': 200,
        'headers': {
            'Content-Type': 'text/plain'
        },
        'body': '{}\n'.format(response.json())
    }