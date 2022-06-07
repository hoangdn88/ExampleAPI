pipeline {
    agent any
    environment {
		DOCKERHUB_CREDENTIALS=credentials('dockerhub')
	}
    stages {
        stage("build") {
            steps {
                script {
                    sh "docker build -f Dockerfile -t hoangdntb88/ampleapi:latest ."
                    
                    //clean to save disk
					sh "docker image rm hoangdntb88/ampleapi:latest"
					
					sh "docker image prune -f"
                }               

            }
        }
		
		stage("Login") {

			steps {
				sh "echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin"
			}
		}
		
		stage("Push") {

			steps {
				sh "docker push hoangdntb88/ampleapi:latest"
			}
		}
        
        stage("deploy") {
            steps {
                sshagent(credentials: ['ssh']) {
                    sh "ssh -o StrictHostKeyChecking=no -l ubuntu 3.110.0.28 '/home/ubuntu/example_server.sh'"
                }
            }
        }
    }
    
    post {
		always {  
			sh 'docker logout'     
		} 
        success {
            echo "SUCCESSFUL"
        }
        failure {
            echo "FAILED"
        }
    }
}
