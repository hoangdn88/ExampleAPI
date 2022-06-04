pipeline {
    agent any
    environment {
        REPOSITORY_URI = "exampleapi" 
		
		EXAMPLE_API_TAG = "1.0"
		EXAMPLE_API_PORT = "8888"
		
		BUILD_TAG = ""
      }
    
    stages {        
        stage("build") {
            steps {
                script {
                    BUILD_TAG="${GIT_BRANCH.tokenize('/').pop()}-${BUILD_NUMBER}-${GIT_COMMIT.substring(0,7)}"
                    					
					echo "build stage tag: ${EXAMPLE_API_TAG}"                    					
                    sh "docker build -f Dockerfile -t ${REPOSITORY_URI}:${EXAMPLE_API_TAG}.${BUILD_TAG} --build-arg SERVICE=${EXAMPLE_API_TAG} --build-arg PORT=${EXAMPLE_API_PORT} ."					
                    sh "docker push ${REPOSITORY_URI}:${EXAMPLE_API_TAG}.${BUILD_TAG}"

                    //clean to save disk
					sh "docker image rm ${REPOSITORY_URI}:${EXAMPLE_API_TAG}.${BUILD_TAG}"
					
					sh "docker image prune -f"
                }               

            }
        }
        
        stage("deploy") {
            steps {
                echo "deploy stage tag: ${EXAMPLE_API_TAG}.${BUILD_TAG}"
				
                //sshagent(credentials: ['bsafe-deploy-server-ssh']) {
                    //sh "ssh -o StrictHostKeyChecking=no -l ${env.BSAFE_DEV_SERVER_USER} ${env.BSAFE_DEV_SERVER_IP} './deploy_bsafe_device_gateway_server.sh ${REPOSITORY_URI}:${EXAMPLE_API_TAG}.${BUILD_TAG} ${EXAMPLE_API_TAG} ${EXAMPLE_API_PORT}'" 
                //}
            }
        }
    }
    
    post {
        success {
            echo "SUCCESSFUL"
			//telegramSend(message: 'BUILD SUCCESSFUL', chatId: '${env.TELEGRAM_BUILD_NOTIFICATION_CHAT_ID}')
        }
        failure {
            echo "FAILED"			
			//telegramSend(message: 'BUILD FAILED', chatId: '${env.TELEGRAM_BUILD_NOTIFICATION_CHAT_ID}')
        }
    }
}
