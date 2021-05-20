#!/usr/bin/env groovy
pipeline{
    agent any

    //Define stages for the build process
    stages{
        //Define the deploy stage
        stage('Deploy'){
            steps{
                //The Jenkins Declarative Pipeline does not provide functionality to deploy to a private
                //Docker registry. In order to deploy to the HDAP Docker registry we must write a custom Groovy
                //script using the Jenkins Scripting Pipeline. This is done by placing Groovy code with in a "script"
                //element. The script below registers the HDAP Docker registry with the Docker instance used by
                //the Jenkins Pipeline, builds a Docker image of the project, and pushes it to the registry.
                script{
                    docker.withRegistry('https://build.hdap.gatech.edu'){
                        //Build and push the database image
                        def databaseImage = docker.build("server-image:${env.BUILD_ID}", "-f ./Fhir/FhirApp/FhirApp/Dockerfile ./Fhir/FhirApp/FhirApp")
                        databaseImage.push('latest')

                        //Build and push the web application image
                        def applicationImage = docker.build("client-image:${env.BUILD_ID}","-f ./frontend/Dockerfile.dev ./frontend")
                        applicationImage.push('latest')
                    }
                }
            }
        }

        //Define stage to notify rancher
        stage('Notify'){
            steps{
                script{
                    rancher confirm: true, credentialId: 'rancher-server', endpoint: 'https://rancher.hdap.gatech.edu/v2-beta', environmentId: '1a7', environments: '', image: 'build.hdap.gatech.edu/server-image:latest', ports: '', service: 'Fhir-Ai-App/server', timeout: 60
                    rancher confirm: true, credentialId: 'rancher-server', endpoint: 'https://rancher.hdap.gatech.edu/v2-beta', environmentId: '1a7', environments: '', image: 'build.hdap.gatech.edu/client-image:latest', ports: '', service: 'Fhir-Ai-App/client', timeout: 60
                }
            }
        }
    }
}
