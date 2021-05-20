ClarityNLP owned by Georgia Tech Research Institute, is developed to streamline analysis of unstructured clinical text. The platform itself accelerates review and extract clinical information including research, clinical care, and quality metrics.

Technique:

ClarityNLP libraries + NLPQLLocal

Environment Requirements:

ClarityNLP Dockercontainer/Postgre/Mongodb/ApacheSolr/Luigi/Redis

The C# Regex is transplanted from ClarityNLP context algorithm project with &quot;/r&quot; quoted the Regex part, which that it enables the users typed in search keywords and then search from the particular category that was split by Regex within clinical articles. It enhances the efficiency of searching and comes out the target search result inclined more to what users want. The function has the ability to handle plural forms of final word.

In order to improve the current .NET regex solution, following term triggers could be applied in model to improve the text mining accuracy:

- experiencer\_triggers

- hypotherical\_triggers

- hypothetical\_triggers

- negex\_triggers

Those triggers does function the same way as &#39;default filter&#39; on text learning and mining. It provides additinal options to this FHIR Al project on deep &#39;understanding&#39; the sentences on PubMed.

![alt text](https://github.gatech.edu/gt-cs6440-hit-spring2019/FHIR-AI-enabled-Appeal-for-Radio-Frequency-Ablation-RFA-Pain-Management-Therapy/blob/master/Screen%20Shot%202019-04-24%20at%2012.48.18%20AM.png)

Another famous NLP approach is utilizing python NLTK tokenization.

The module combination attempts to improve upon spaCy&#39;s sentence tokenization. It is important to cleanup and token substitution on those not generally found in standard written English, like abbreviation, spatial measurements.

Application Environment: Python + NLTK libraries + ClarityNLP seg\_helper (unstructured clinical text segmentation)

![alt text](https://github.gatech.edu/gt-cs6440-hit-spring2019/FHIR-AI-enabled-Appeal-for-Radio-Frequency-Ablation-RFA-Pain-Management-Therapy/blob/master/Picture1.png)

Input:

- Individual article text

- config file for ClarityNLP SOLR ingest

- regex filter

Output:

a list of tokenized-cleaned sentences for claim template fill in

The python module can be run from the command line for testing and debugging. It will

process a JSON file properly configured for ClarityNLP SOLR ingest (i.e. each

JSON record needs a &#39;report\_text&#39; field), extract the &#39;report\_text&#39; field,

split it into sentences, and print each sentence to the screen.

Help for command line operation can be obtained with this command:

python3 ./segmentation.py --help

Some examples to run original segmentation and helper @[https://github.com/ClarityNLP/ClarityNLP/tree/master/nlp/algorithms/segmentation](https://github.com/ClarityNLP/ClarityNLP/tree/master/nlp/algorithms/segmentation)

To tokenize all reports in myfile.json and print each sentence to stdout:

python3 ./segmentation.py -f /path/to/myfile.json

To tokenize only the first 10 reports (indices begin with 0):

python3 ./segmentation.py -f myfile.json --end 9

To tokenize reports 115 through 134 inclusively, and to also show the report text

after cleanup and token substitution (immediately prior to tokenization):

python3 ./segmentation.py -f myfile.json --start 115 --end 134 --debug

Useful link and resource regarding to NLP CI testing via running service Claritynlpass

The FHIR client tester:

[https://smartlauncher.apps.hdap.gatech.edu/ehr.html?app=https%3A%2F%2Fnlp.hdap.gatech.edu%2Ffhirclient%2F%3Flaunch%3DeyJhIjoiMSIsImYiOiIxIn0%26iss%3Dhttps%253A%252F%252Fsmartlauncher.apps.hdap.gatech.edu%252Fv%252Fr3%252Ffhir&amp;user](https://smartlauncher.apps.hdap.gatech.edu/ehr.html?app=https%3A%2F%2Fnlp.hdap.gatech.edu%2Ffhirclient%2F%3Flaunch%3DeyJhIjoiMSIsImYiOiIxIn0%26iss%3Dhttps%253A%252F%252Fsmartlauncher.apps.hdap.gatech.edu%252Fv%252Fr3%252Ffhir&amp;user)=

Current ClarityNLPaaS job types:

[https://nlp.hdap.gatech.edu/job/list/all](https://nlp.hdap.gatech.edu/job/list/all)

Sample POST to Claritynlpass at hdap with returns the NLP results:

[https://nlp.hdap.gatech.edu/job/oncology/Cancer\_laterality](https://nlp.hdap.gatech.edu/job/oncology/Cancer_laterality)

Example：

{

&quot;reports&quot;: [

&quot;Cause of Death A:\nRESPIRATORY SYSTEM FAILURE. \n\n\nInterval of Death A:\nDAYS. \n\n \nCause of Death B:\nRIGHT PLEURAL CARCINOMA WITH EFFUSION AND COLLAPSE OF RIGHT LUNG. \n\n\nInterval of Death B:\nDAYS. \n\n \nCause of Death C:\nLEFT PLEURAL CARCINOMA WITH EFFUSION AND COLLAPSE OF LEFT LUNG. \n\n\nInterval of Death C:\n3 WEEKS. \n\n \nCause of Death D:\nESOPHAGEAL CANCER (SIGNET RING ADENOCARCINOMA). \n\n\nInterval of Death D:\n1 YEAR +. \n\n \nAdditional Conditions:\nESOPHAGEAL OBSTRUCTION AND PROBABLE ASPIRATION.&quot;

]

}

The endpoint to test NLPQL:

[https://nlp.hdap.gatech.edu/job/validate\_nlpql](https://nlp.hdap.gatech.edu/job/validate_nlpql)

For valid plain text NLPQL post, it will parse to JSON against patient data.

Sample testing via Postman:

![alt text](https://github.gatech.edu/gt-cs6440-hit-spring2019/FHIR-AI-enabled-Appeal-for-Radio-Frequency-Ablation-RFA-Pain-Management-Therapy/blob/master/image.png)

_https://nlp.hdap.gatech.edu/job/register\_nlpql_

This don&#39;t persist after the server restarts (Which is usually just when CI runs), but they are good for testing.

After you upload custom, you should see it here:

https://nlp.hdap.gatech.edu/job/list/all

running by POSTIng just like other jobs, e.g.

https://nlp.hdap.gatech.edu/job/custom/custom\_Karnofksy\_Score\_v1

