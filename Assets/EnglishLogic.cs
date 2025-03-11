using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class EnglishLogic : MonoBehaviour
{
    public TMP_Dropdown tenseDropdown;
    public TMP_Dropdown phraseTypeDropdown;

    [SerializeField] GameObject rememberPanel;

    public TMP_InputField userInputField;
    public Button checkButton;
    public TMP_Text feedbackText;
    public TMP_Text rule_dynamic_text;
    public string selectedTense = ""; // Cambia a seconda dell'esercizio

    // Fare HelpMe Button che mostra una delle frasi dopo la pubblicità

    #region QUESTIONS INITIALIZATION
    public HashSet<string> present_simple_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
    "Do you like ice cream?",
    "Does he play football?",
    "Do they watch movies on weekends?",
    "Does she enjoy reading books?",
    "Do we need more water?",
    "Does the cat sleep on the couch?",
    "Do the kids go to school every day?",
    "Does John write emails every morning?",
    "Do my parents visit their neighbors?",
    "Does the teacher explain the rules clearly?",
    "Do you enjoy listening to music?",
    "Does Sarah bake cakes often?",
    "Do the students clean the classroom?",
    "Does Alice play the piano?",
    "Does he drive to work every morning?",
    "Do we celebrate holidays with our family?",
    "Does Mike read the newspaper daily?",
    "Do the workers repair the building?",
    "Does your cat chase the birds?",
    "Do they swim in the pool during summer?",
    "Does Tom fix the bicycles?",
    "Do the tourists visit the museum?",
    "Does Emma sing beautifully?",
    "Do you drink coffee in the morning?",
    "Does David play the guitar?",
    "Do we buy groceries every Saturday?",
    "Does Lily enjoy painting?",
    "Do the nurses help patients?",
    "Does the baby cry at night?",
    "Does he teach English at school?",
    "Do my friends watch TV at night?",
    "Does the dog bark loudly?",
    "Do you write in your notebook daily?",
    "Does she walk to work?",
    "Do they play basketball every weekend?",
    "Does Jack study math in the evening?",
    "Do you prefer tea over coffee?",
    "Do my cousins bake cookies?",
    "Does the professor check the reports?",
    "Do the birds sing in the morning?",
    "Does the manager organize the meetings?",
    "Do the engineers build bridges?",
    "Does he swim in the lake?",
    "Do we dance at parties?",
    "Do the kids play video games?",
    "Does the train arrive on time?",
    "Do the glasses improve vision?",
    "Does James enjoy cycling?",
    "Does the car stop at the red light?",
    "Do the students learn new skills?",
    "Does her brother like football?",
    "Do you enjoy walking in the countryside?",
    "Does the gardener plant flowers?",
    "Do we listen to podcasts?",
    "Does the baby sleep during the day?",
    "Do the teachers explain grammar rules?",
    "Do they celebrate birthdays?",
    "Does he fix his bike on weekends?",
    "Do you speak English fluently?",
    "Does Alice clean the windows regularly?",
    "Do we cook dinner together every evening?",
    "Does Mike travel during the holidays?",
    "Do the classmates solve puzzles?",
    "Does she admire the sunset?",
    "Do the clients request urgent updates?",
    "Does the librarian lend books?",
    "Do we enjoy watching documentaries?",
    "Does Tom prefer classical music?",
    "Do my neighbors invite guests for dinner?",
    "Does John attend meetings frequently?",
    "Do they enjoy playing chess?",
    "Does Emma decorate the house for Christmas?",
    "Do the workers finish their tasks on time?",
    "Does the professor answer the questions?",
    "Do we celebrate festivals together?",
    "Does the director plan the schedule?",
    "Does Sarah read novels every weekend?",
    "Do the students practice their speeches?",
    "Does the baby smile often?",
    "Do the nurses assist the patients?",
    "Does she like watching comedies?",
    "Do the kids learn new games?",
    "Does the manager conduct interviews?",
    "Do you visit the museum on Fridays?",
    "Does James paint beautiful landscapes?",
    "Does the chef prepare delicious meals?",
    "Do the students write essays?",
    "Does John attend the conference?",
    "Do we share ideas in meetings?",
    "Does Tom live in the city?",
    "Do the kids go camping?",
    "Does Mike organize workshops?",
    "Do the birds fly over the hill?",
    "Does the dog run in the park?",
    "Do we prepare for exams?",
    "Does Alice finish her work early?",
    "Does Sarah build sandcastles?",
    "Do my cousins watch action movies?",
    "Does Emma love her family?",
    "Does the manager recommend changes?",
    "Do we arrange the furniture?",
    "Does he prefer wearing casual clothes?",
    "Do you open the windows in the morning?",
    "Does she enjoy playing the violin?",
    "Does David teach science?",
    "Do we watch the sunrise?",
    "Does John collect coins?",
    "Do they repair old furniture?",
    "Does she love traveling to new places?",
    "Does the teacher praise the students?",
    "Does Sarah perform in the theater?",
    "Do we paint the house?",
    "Does Tom sing in the choir?",
    "Does he watch sports on TV?",
    "Do we study together?",
    "Does the artist create portraits?",
    "Do the tourists take pictures?",
    "Does Alice design jewelry?",
    "Does Jack spend time with his parents?",
    "Do the musicians perform in concerts?",
    "Does John ride his bike to school?",
    "Do the cats sleep on the bed?",
    "Does the dog wag its tail?",
    "Does the teacher assign homework?",
    "Do we wash the dishes after dinner?",
    "Does Emma review her notes?",
    "Do the hikers climb the mountain?",
    "Does the organizer plan events?",
    "Do they attend the workshop?",
    "Does the host welcome guests warmly?",
    "Do the children draw sketches?",
    "Does the chef bake cakes?",
    "Do the travelers explore the city?",
    "Does the student ask questions?",
    "Does the baker knead the dough?",
    "Do we brainstorm ideas?",
    "Does he read poetry?",
    "Do the parents help with homework?",
    "Does the doctor treat patients?",
    "Does the artist sketch daily?",
    "Does she travel to Italy?",
    "Do they play the piano?",
    "Does John sew clothes?",
    "Does the host serve coffee?",
    "Does the singer rehearse daily?",
    "Do we memorize speeches?",
    "Does he complete his assignments?",
    "Do the gardeners water the plants?",
    "Does Lily admire nature?",
    "Do they attend church on Sundays?",
    "Does Sarah polish the table?",
    "Do you find this interesting?",
    "Does Mike analyze the report?",
    "Does he paint the walls?",
    "Do the kids laugh loudly?",
    "Do we celebrate Christmas?",
    "Does she enjoy solving puzzles?",
    "Do the cyclists ride fast?",
    "Do we order pizza?",
    "Does he brush his teeth regularly?",
    "Does the team practice every day?",
    "Do they win championships?",
    "Do the birds chirp in the morning?",
    "Does John coach the team?",
    "Does the carpenter craft furniture?",
    "Does Emma write poetry?",
    "Do they edit the manuscript?",
    "Does she rehearse her lines?",
    "Does he wipe the floor?",
    "Do we attend the seminar?"
    };
    public HashSet<string> present_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
    "Is she reading a book?",
    "Are they watching a movie?",
    "Is he playing football?",
    "Are you studying for the exam?",
    "Am I doing this correctly?",
    "Is the dog barking loudly?",
    "Are the kids playing in the park?",
    "Is John fixing the car?",
    "Are my parents working in the garden?",
    "Is the teacher explaining the lesson?",
    "Are we helping with the project?",
    "Are the birds singing in the morning?",
    "Is Sarah writing an email?",
    "Are the students discussing the problem?",
    "Is Alice playing the piano?",
    "Are you cleaning the windows?",
    "Is Mike organizing the meeting?",
    "Are they traveling to the city?",
    "Is the cat sleeping on the couch?",
    "Is Emma baking a cake?",
    "Are we solving puzzles together?",
    "Is Tom painting the house?",
    "Is David teaching English?",
    "Are my cousins visiting the museum?",
    "Are the workers repairing the bridge?",
    "Is James preparing dinner?",
    "Are the kids building a sandcastle?",
    "Is the train arriving on time?",
    "Are the tourists taking pictures?",
    "Is Jack designing the poster?",
    "Am I helping you with the task?",
    "Is the manager organizing the workshop?",
    "Are the nurses caring for the patients?",
    "Is the baby crying at night?",
    "Are we arranging the decorations?",
    "Is the dog wagging its tail?",
    "Are the glasses reflecting the light?",
    "Is the librarian lending books?",
    "Is he solving a difficult problem?",
    "Are the musicians performing on stage?",
    "Is Lily drawing a beautiful sketch?",
    "Are the chefs preparing delicious meals?",
    "Is the sun setting over the hill?",
    "Is the carpenter building new furniture?",
    "Are the kids riding their bikes?",
    "Are you watering the plants?",
    "Are we exploring the countryside?",
    "Is the teacher checking the homework?",
    "Are they feeding the animals?",
    "Is the baby sleeping peacefully?",
    "Are my neighbors inviting guests?",
    "Is Alice sewing a new dress?",
    "Is Emma designing a website?",
    "Are the students revising for the exam?",
    "Is Sarah explaining the rules?",
    "Are the birds flying over the trees?",
    "Is he learning to play the guitar?",
    "Am I improving my skills?",
    "Is the software updating automatically?",
    "Is the doctor treating the patients?",
    "Are the organizers planning the event?",
    "Are you repairing the fence?",
    "Is the team practicing for the match?",
    "Is Mike ironing his shirt?",
    "Are we planting flowers in the garden?",
    "Is John painting a portrait?",
    "Are the children arranging the books?",
    "Is Tom collecting the tickets?",
    "Is Lily polishing the silverware?",
    "Are we dusting the furniture?",
    "Is the computer processing the data?",
    "Are the workers building the new office?",
    "Are the kids drawing pictures?",
    "Is Sarah rehearsing her lines?",
    "Is the pianist performing on the stage?",
    "Are they brainstorming ideas?",
    "Is the family decorating the Christmas tree?",
    "Is the director discussing the project?",
    "Are we organizing the party?",
    "Is Emma analyzing the report?",
    "Is the manager holding a meeting?",
    "Is the host welcoming the guests?",
    "Are they climbing the mountain?",
    "Are we finishing our assignments?",
    "Are the travelers packing their bags?",
    "Is the artist creating a sculpture?",
    "Is the student preparing for the presentation?",
    "Is the librarian organizing the books?",
    "Are the kids playing chess?",
    "Is the baker kneading the dough?",
    "Is she helping her mother in the kitchen?",
    "Are the engineers designing the bridge?",
    "Is the technician repairing the equipment?",
    "Are the kids jumping on the trampoline?",
    "Is the guard opening the gate?",
    "Are they waiting for the train?",
    "Is the boat sailing across the river?",
    "Are the teachers reviewing the essays?",
    "Is John explaining the solution?",
    "Is Mike practicing the piano?",
    "Are the dogs running around the park?",
    "Is Tom driving to the office?",
    "Is Emma studying for her test?",
    "Are the students practicing their presentation?",
    "Are you folding the clothes?",
    "Is the team preparing for the competition?",
    "Is he organizing the files?",
    "Are the kids playing hide and seek?",
    "Is Sarah writing her diary?",
    "Are we enjoying the beautiful weather?",
    "Is the teacher guiding the students?",
    "Are the actors rehearsing for the play?",
    "Is the dog chasing the cat?",
    "Is the chef tasting the soup?",
    "Is the scientist conducting an experiment?",
    "Are the volunteers distributing the leaflets?",
    "Is he adjusting the camera settings?",
    "Are you checking your emails?",
    "Is the team celebrating their victory?",
    "Is the customer placing an order?",
    "Are we waiting for the bus?",
    "Is the musician tuning the guitar?",
    "Are the kids behaving well?",
    "Is the professor explaining the concepts?",
    "Are the artists performing at the festival?",
    "Are we cleaning the house together?",
    "Is the child crying for candy?",
    "Is the coach training the players?",
    "Are the students completing their homework?",
    "Is she trying on a new dress?",
    "Are we meeting the manager?",
    "Is Mike sending the invitation?",
    "Are the dogs barking at strangers?",
    "Is the staff organizing the conference?",
    "Are the tourists exploring the museum?",
    "Is the waiter serving the food?",
    "Are the parents watching their kids play?",
    "Is the dog digging in the backyard?",
    "Is the actor practicing his lines?",
    "Are you explaining the instructions?",
    "Is the robot cleaning the floor?",
    "Are the flowers blooming in the garden?",
    "Is the programmer debugging the code?",
    "Are they relaxing on the couch?",
    "Are we discussing the plan?",
    "Is the student raising her hand?",
    "Are the neighbors moving to a new house?",
    "Is the teacher assigning tasks?",
    "Is the artist sketching a landscape?",
    "Is the cat chasing the mouse?",
    "Are the players warming up for the match?",
    "Are the kids swinging on the swings?",
    "Are you painting the fence?",
    "Is the chef experimenting with new recipes?",
    "Is the librarian stacking the books?"
    };
    public HashSet<string> present_perfect_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
    "Have you completed your homework?",
    "Has she read that book?",
    "Have they visited the museum?",
    "Has he ever played football?",
    "Have we finished our tasks?",
    "Has the dog barked all night?",
    "Have the kids eaten their lunch?",
    "Has John written an email?",
    "Have my parents cleaned the house?",
    "Has the teacher explained the rules?",
    "Have we ever been to Paris?",
    "Has the bird flown over the hill?",
    "Has Sarah baked a cake?",
    "Have the students studied for the exam?",
    "Has Alice played the piano?",
    "Have you washed the dishes?",
    "Has Mike organized the files?",
    "Have they gone to the market?",
    "Has the cat slept on the couch?",
    "Has Emma finished her project?",
    "Have we solved the puzzle?",
    "Has Tom painted the fence?",
    "Has David taught English?",
    "Have my cousins visited Italy?",
    "Have the workers repaired the bridge?",
    "Has James prepared dinner?",
    "Have the kids built a sandcastle?",
    "Has the train arrived on time?",
    "Have the tourists taken pictures?",
    "Has Jack designed the logo?",
    "Have I helped you with the task?",
    "Has the manager organized the meeting?",
    "Have the nurses treated the patients?",
    "Has the baby cried all morning?",
    "Have we arranged the decorations?",
    "Has the dog wagged its tail?",
    "Have the glasses reflected the sunlight?",
    "Have the librarians sorted the books?",
    "Has he solved the math problem?",
    "Have the musicians performed at the event?",
    "Has Lily sketched a portrait?",
    "Have the chefs prepared the dishes?",
    "Has the sun set over the horizon?",
    "Has the carpenter built a new table?",
    "Have the kids ridden their bikes?",
    "Have you watered the plants?",
    "Have we explored the countryside?",
    "Has the teacher checked the homework?",
    "Have they fed the animals?",
    "Has the baby slept peacefully?",
    "Have my neighbors invited guests?",
    "Has Alice sewn a new dress?",
    "Has Emma created a website?",
    "Have the students revised for the test?",
    "Has Sarah explained the instructions?",
    "Have the birds flown across the fields?",
    "Has he learned to play the guitar?",
    "Have I improved my grades?",
    "Has the software updated automatically?",
    "Has the doctor treated the patients?",
    "Have the organizers planned the event?",
    "Have you repaired the roof?",
    "Has the team practiced for the tournament?",
    "Has Mike ironed his clothes?",
    "Have we planted flowers in the garden?",
    "Has John painted a masterpiece?",
    "Have the children arranged the chairs?",
    "Has Tom collected the tickets?",
    "Has Lily polished the silverware?",
    "Have we dusted the furniture?",
    "Has the computer processed the data?",
    "Have the workers built a new office?",
    "Have the kids drawn pictures?",
    "Has Sarah rehearsed her lines?",
    "Has the pianist performed on stage?",
    "Have they brainstormed new ideas?",
    "Has the family decorated the Christmas tree?",
    "Has the director discussed the agenda?",
    "Have we organized the festival?",
    "Has Emma analyzed the report?",
    "Has the manager held a meeting?",
    "Has the host welcomed the guests?",
    "Have they climbed the mountain?",
    "Have we finished our assignments?",
    "Have the travelers packed their bags?",
    "Has the artist created a sculpture?",
    "Has the student prepared a presentation?",
    "Have the librarians rearranged the shelves?",
    "Have the kids played a board game?",
    "Has the baker kneaded the dough?",
    "Has she helped her mother with cooking?",
    "Have the engineers designed the new structure?",
    "Has the technician repaired the printer?",
    "Have the kids jumped on the trampoline?",
    "Has the guard opened the gates?",
    "Have they waited for the bus?",
    "Has the boat sailed across the river?",
    "Have the teachers reviewed the assignments?",
    "Has John explained the solution?",
    "Has Mike practiced the piano?",
    "Have the dogs run in the garden?",
    "Has Tom driven to the store?",
    "Has Emma studied for her math test?",
    "Have the students delivered their projects?",
    "Have you folded the clothes?",
    "Has the team practiced for the championship?",
    "Has he organized the event?",
    "Have the kids played hide and seek?",
    "Has Sarah written a poem?",
    "Have we enjoyed the music?",
    "Has the teacher guided the students?",
    "Have the actors rehearsed their roles?",
    "Has the dog chased the cat?",
    "Has the chef tasted the soup?",
    "Has the scientist conducted the experiment?",
    "Have the volunteers distributed flyers?",
    "Has he adjusted the lighting?",
    "Have you read all the emails?",
    "Has the team celebrated their win?",
    "Has the customer placed an order?",
    "Have we waited for the train?",
    "Has the musician tuned the guitar?",
    "Have the kids behaved well?",
    "Has the professor explained the concept?",
    "Have the artists performed at the gallery?",
    "Have we cleaned the house?",
    "Has the child cried loudly?",
    "Has the coach trained the players?",
    "Have the students completed the task?",
    "Has she tried the new recipe?",
    "Have we met the new manager?",
    "Has Mike sent the invitations?",
    "Have the dogs barked all night?",
    "Has the staff organized the seminar?",
    "Have the tourists explored the monument?",
    "Has the waiter served the drinks?",
    "Have the parents watched their kids?",
    "Has the dog dug a hole?",
    "Has the actor practiced his lines?",
    "Have you explained the process?",
    "Has the robot cleaned the floor?",
    "Have the flowers bloomed in spring?",
    "Has the programmer fixed the bug?",
    "Have they relaxed in the lounge?",
    "Have we discussed the new ideas?",
    "Has the student answered the question?",
    "Have the neighbors moved to a new apartment?",
    "Has the teacher assigned the projects?",
    "Has the artist painted a new piece?",
    "Has the cat chased the mouse?",
    "Have the players warmed up?",
    "Have the kids swung on the swings?",
    "Have you painted the room?",
    "Has the chef prepared new dishes?",
    "Have the librarians stacked the books?",
    "Have the bakers decorated the cakes?"
    };
    public HashSet<string> present_perfect_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
          "Have you been reading that book?",
    "Has she been working on her project?",
    "Have they been playing football all day?",
    "Has he been watching the movie?",
    "Have we been cleaning the house?",
    "Has the dog been barking loudly?",
    "Have the kids been playing in the garden?",
    "Has John been fixing the car?",
    "Have my parents been organizing the party?",
    "Has the teacher been explaining the lesson?",
    "Have we been helping with the task?",
    "Has the cat been sleeping on the couch?",
    "Has Sarah been writing her essay?",
    "Have the students been studying for the exam?",
    "Has Alice been practicing the piano?",
    "Have you been washing the dishes?",
    "Has Mike been arranging the files?",
    "Have they been traveling to the city?",
    "Has Emma been baking a cake?",
    "Have we been solving puzzles together?",
    "Has Tom been painting the fence?",
    "Has David been teaching English?",
    "Have my cousins been visiting the museum?",
    "Have the workers been repairing the bridge?",
    "Has James been preparing dinner?",
    "Have the kids been building a sandcastle?",
    "Has the train been arriving late?",
    "Have the tourists been taking pictures?",
    "Has Jack been designing the poster?",
    "Have I been helping you with the project?",
    "Has the manager been organizing meetings?",
    "Have the nurses been treating the patients?",
    "Has the baby been crying all morning?",
    "Have we been arranging the decorations?",
    "Has the gardener been planting flowers?",
    "Have the students been discussing their projects?",
    "Has the librarian been sorting the books?",
    "Has he been solving a difficult math problem?",
    "Have the musicians been performing on stage?",
    "Has Lily been sketching a portrait?",
    "Have the chefs been preparing the meals?",
    "Has the sun been setting over the hill?",
    "Has the carpenter been building furniture?",
    "Have the kids been riding their bikes?",
    "Have you been watering the plants?",
    "Have we been exploring the countryside?",
    "Has the teacher been checking the homework?",
    "Have they been feeding the animals?",
    "Has the baby been sleeping peacefully?",
    "Have my neighbors been inviting guests?",
    "Has Alice been sewing a dress?",
    "Has Emma been designing a new website?",
    "Have the students been revising for the test?",
    "Has Sarah been explaining the instructions?",
    "Have the birds been flying over the lake?",
    "Has he been learning to play the guitar?",
    "Have I been improving my skills?",
    "Has the software been updating automatically?",
    "Has the doctor been treating the patients?",
    "Have the organizers been planning the event?",
    "Have you been repairing the fence?",
    "Has the team been practicing for the championship?",
    "Has Mike been ironing his clothes?",
    "Have we been planting flowers in the garden?",
    "Has John been painting a masterpiece?",
    "Have the children been arranging the chairs?",
    "Has Tom been collecting tickets?",
    "Has Lily been polishing the silverware?",
    "Have we been dusting the furniture?",
    "Has the computer been processing the data?",
    "Have the workers been building the new office?",
    "Have the kids been drawing pictures?",
    "Has Sarah been rehearsing her lines?",
    "Has the pianist been performing on stage?",
    "Have they been brainstorming new ideas?",
    "Has the family been decorating the Christmas tree?",
    "Has the director been discussing the agenda?",
    "Have we been organizing the workshop?",
    "Has Emma been analyzing the report?",
    "Has the manager been holding meetings?",
    "Has the host been welcoming the guests?",
    "Have they been climbing the mountain?",
    "Have we been finishing our assignments?",
    "Have the travelers been packing their bags?",
    "Has the artist been creating a sculpture?",
    "Has the student been preparing for a presentation?",
    "Have the librarians been rearranging the shelves?",
    "Have the kids been playing board games?",
    "Has the baker been kneading the dough?",
    "Has she been helping her mother cook?",
    "Have the engineers been designing the new project?",
    "Has the technician been repairing the printer?",
    "Have the kids been jumping on the trampoline?",
    "Has the guard been opening the gates?",
    "Have they been waiting for the bus?",
    "Has the boat been sailing across the river?",
    "Have the teachers been reviewing the homework?",
    "Has John been explaining the solution?",
    "Has Mike been practicing the piano?",
    "Have the dogs been running in the garden?",
    "Has Tom been driving to the office?",
    "Has Emma been studying for her test?",
    "Have the students been delivering their projects?",
    "Have you been folding the clothes?",
    "Has the team been preparing for the tournament?",
    "Has he been organizing the schedule?",
    "Have the kids been playing hide and seek?",
    "Has Sarah been writing her journal?",
    "Have we been enjoying the music?",
    "Has the teacher been guiding the students?",
    "Have the actors been rehearsing their roles?",
    "Has the dog been chasing the cat?",
    "Has the chef been tasting the soup?",
    "Has the scientist been conducting experiments?",
    "Have the volunteers been distributing flyers?",
    "Has he been adjusting the settings?",
    "Have you been checking your emails?",
    "Has the team been celebrating their victory?",
    "Has the customer been placing orders?",
    "Have we been waiting for the train?",
    "Has the musician been tuning the guitar?",
    "Have the kids been behaving well?",
    "Has the professor been explaining the concept?",
    "Have the artists been performing at the gallery?",
    "Have we been cleaning the house?",
    "Has the child been crying loudly?",
    "Has the coach been training the players?",
    "Have the students been completing their homework?",
    "Has she been trying a new recipe?",
    "Have we been meeting with the manager?",
    "Has Mike been sending invitations?",
    "Have the dogs been barking loudly?",
    "Has the staff been organizing the seminar?",
    "Have the tourists been exploring the monument?",
    "Has the waiter been serving the drinks?",
    "Have the parents been watching their kids?",
    "Has the dog been digging in the garden?",
    "Has the actor been practicing his lines?",
    "Have you been explaining the instructions?",
    "Has the robot been cleaning the floor?",
    "Have the flowers been blooming in the garden?",
    "Has the programmer been fixing the bug?",
    "Have they been relaxing in the lounge?",
    "Have we been discussing the ideas?",
    "Has the student been answering the questions?",
    "Have the neighbors been moving to a new house?",
    "Has the teacher been assigning projects?",
    "Has the artist been painting a new masterpiece?",
    "Has the cat been chasing the mouse?",
    "Have the players been warming up for the match?",
    "Have the kids been swinging on the swings?",
    "Have you been painting the walls?",
    "Has the chef been preparing new recipes?",
    "Have the librarians been stacking the books?",
    "Have the bakers been decorating the cakes?"
    };

    public HashSet<string> past_simple_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
        "Did you read that book?",
    "Did she watch the movie last night?",
    "Did they play football yesterday?",
    "Did he finish his homework?",
    "Did we clean the house?",
    "Did the dog bark loudly?",
    "Did the kids play in the garden?",
    "Did John fix the car?",
    "Did my parents organize the party?",
    "Did the teacher explain the lesson?",
    "Did we help with the task?",
    "Did the cat sleep on the couch?",
    "Did Sarah write an essay?",
    "Did the students study for the exam?",
    "Did Alice practice the piano?",
    "Did you wash the dishes?",
    "Did Mike arrange the files?",
    "Did they travel to the city?",
    "Did Emma bake a cake?",
    "Did we solve the puzzle?",
    "Did Tom paint the fence?",
    "Did David teach English?",
    "Did my cousins visit the museum?",
    "Did the workers repair the bridge?",
    "Did James prepare dinner?",
    "Did the kids build a sandcastle?",
    "Did the train arrive on time?",
    "Did the tourists take pictures?",
    "Did Jack design the poster?",
    "Did I help you with the project?",
    "Did the manager organize the meeting?",
    "Did the nurses treat the patients?",
    "Did the baby cry all morning?",
    "Did we arrange the decorations?",
    "Did the gardener plant flowers?",
    "Did the students discuss their projects?",
    "Did the librarian sort the books?",
    "Did he solve a difficult math problem?",
    "Did the musicians perform on stage?",
    "Did Lily sketch a portrait?",
    "Did the chefs prepare the meals?",
    "Did the sun set over the hill?",
    "Did the carpenter build furniture?",
    "Did the kids ride their bikes?",
    "Did you water the plants?",
    "Did we explore the countryside?",
    "Did the teacher check the homework?",
    "Did they feed the animals?",
    "Did the baby sleep peacefully?",
    "Did my neighbors invite guests?",
    "Did Alice sew a dress?",
    "Did Emma design a new website?",
    "Did the students revise for the test?",
    "Did Sarah explain the instructions?",
    "Did the birds fly over the lake?",
    "Did he learn to play the guitar?",
    "Did I improve my skills?",
    "Did the software update automatically?",
    "Did the doctor treat the patients?",
    "Did the organizers plan the event?",
    "Did you repair the fence?",
    "Did the team practice for the championship?",
    "Did Mike iron his clothes?",
    "Did we plant flowers in the garden?",
    "Did John paint a masterpiece?",
    "Did the children arrange the chairs?",
    "Did Tom collect tickets?",
    "Did Lily polish the silverware?",
    "Did we dust the furniture?",
    "Did the computer process the data?",
    "Did the workers build the new office?",
    "Did the kids draw pictures?",
    "Did Sarah rehearse her lines?",
    "Did the pianist perform on stage?",
    "Did they brainstorm new ideas?",
    "Did the family decorate the Christmas tree?",
    "Did the director discuss the agenda?",
    "Did we organize the workshop?",
    "Did Emma analyze the report?",
    "Did the manager hold meetings?",
    "Did the host welcome the guests?",
    "Did they climb the mountain?",
    "Did we finish our assignments?",
    "Did the travelers pack their bags?",
    "Did the artist create a sculpture?",
    "Did the student prepare for a presentation?",
    "Did the librarians rearrange the shelves?",
    "Did the kids play a board game?",
    "Did the baker knead the dough?",
    "Did she help her mother with cooking?",
    "Did the engineers design the new project?",
    "Did the technician repair the printer?",
    "Did the kids jump on the trampoline?",
    "Did the guard open the gates?",
    "Did they wait for the bus?",
    "Did the boat sail across the river?",
    "Did the teachers review the homework?",
    "Did John explain the solution?",
    "Did Mike practice the piano?",
    "Did the dogs run in the garden?",
    "Did Tom drive to the office?",
    "Did Emma study for her test?",
    "Did the students deliver their projects?",
    "Did you fold the clothes?",
    "Did the team prepare for the tournament?",
    "Did he organize the schedule?",
    "Did the kids play hide and seek?",
    "Did Sarah write a journal?",
    "Did we enjoy the music?",
    "Did the teacher guide the students?",
    "Did the actors rehearse their roles?",
    "Did the dog chase the cat?",
    "Did the chef taste the soup?",
    "Did the scientist conduct experiments?",
    "Did the volunteers distribute flyers?",
    "Did he adjust the settings?",
    "Did you check your emails?",
    "Did the team celebrate their victory?",
    "Did the customer place orders?",
    "Did we wait for the train?",
    "Did the musician tune the guitar?",
    "Did the kids behave well?",
    "Did the professor explain the concept?",
    "Did the artists perform at the gallery?",
    "Did we clean the house?",
    "Did the child cry loudly?",
    "Did the coach train the players?",
    "Did the students complete their homework?",
    "Did she try a new recipe?",
    "Did we meet with the manager?",
    "Did Mike send invitations?",
    "Did the dogs bark loudly?",
    "Did the staff organize the seminar?",
    "Did the tourists explore the monument?",
    "Did the waiter serve the drinks?",
    "Did the parents watch their kids?",
    "Did the dog dig in the garden?",
    "Did the actor practice his lines?",
    "Did you explain the instructions?",
    "Did the robot clean the floor?",
    "Did the flowers bloom in the garden?",
    "Did the programmer fix the bug?",
    "Did they relax in the lounge?",
    "Did we discuss the ideas?",
    "Did the student answer the questions?",
    "Did the neighbors move to a new house?",
    "Did the teacher assign the projects?",
    "Did the artist paint a new masterpiece?",
    "Did the cat chase the mouse?",
    "Did the players warm up for the match?",
    "Did the kids swing on the swings?",
    "Did you paint the walls?",
    "Did the chef prepare new recipes?",
    "Did the librarians stack the books?",
    "Did the bakers decorate the cakes?",
    "Did the singer practice new songs?"
    };
    public HashSet<string> past_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "Was she reading that book?",
    "Were they watching the movie?",
    "Was he playing football in the garden?",
    "Were you studying for the exam?",
    "Was I doing the right thing?",
    "Was the dog barking all night?",
    "Were the kids playing in the park?",
    "Was John fixing the car yesterday?",
    "Were my parents organizing the event?",
    "Was the teacher explaining the problem?",
    "Were we helping them with the project?",
    "Was the cat sleeping on the couch?",
    "Was Sarah writing an email?",
    "Were the students studying for the test?",
    "Was Alice practicing the piano?",
    "Were you cleaning the windows earlier?",
    "Was Mike arranging the files?",
    "Were they traveling to the countryside?",
    "Was Emma baking cookies?",
    "Were we solving the puzzle together?",
    "Was Tom painting the wall?",
    "Was David teaching English last week?",
    "Were my cousins visiting the museum?",
    "Were the workers repairing the bridge?",
    "Was James preparing lunch?",
    "Were the kids building a sandcastle?",
    "Was the train arriving late again?",
    "Were the tourists taking photographs?",
    "Was Jack designing a new poster?",
    "Was I helping him with the assignment?",
    "Was the manager organizing the meeting?",
    "Were the nurses treating the patients?",
    "Was the baby crying all morning?",
    "Were we arranging the room for the party?",
    "Was the gardener planting flowers yesterday?",
    "Were the students discussing the answers?",
    "Was the librarian sorting the books?",
    "Was he solving a complex problem?",
    "Were the musicians performing on stage?",
    "Was Lily sketching a picture?",
    "Were the chefs preparing meals in the kitchen?",
    "Was the sun setting over the horizon?",
    "Was the carpenter building the chair?",
    "Were the kids riding their bicycles?",
    "Were you watering the plants?",
    "Were we exploring the new neighborhood?",
    "Was the teacher checking the homework?",
    "Were they feeding the animals?",
    "Was the baby sleeping soundly?",
    "Were my neighbors inviting guests over?",
    "Was Alice sewing a dress for the event?",
    "Was Emma designing a website?",
    "Were the students revising for their exams?",
    "Was Sarah explaining the task to her classmates?",
    "Were the birds flying above the trees?",
    "Was he learning how to play the guitar?",
    "Was I improving my presentation skills?",
    "Was the software updating during the session?",
    "Was the doctor treating a patient?",
    "Were the organizers planning the workshop?",
    "Were you repairing the old bicycle?",
    "Was the team practicing for the finals?",
    "Was Mike ironing his shirt?",
    "Were we planting flowers in the garden?",
    "Was John painting a beautiful portrait?",
    "Were the children arranging their books?",
    "Was Tom collecting tickets at the counter?",
    "Was Lily polishing the tableware?",
    "Were we dusting the furniture?",
    "Was the computer processing the data?",
    "Were the workers building the new office?",
    "Were the kids drawing colorful pictures?",
    "Was Sarah rehearsing her lines for the play?",
    "Was the pianist performing at the concert?",
    "Were they brainstorming ideas for the project?",
    "Was the family decorating the Christmas tree?",
    "Was the director discussing the agenda?",
    "Were we organizing the new department?",
    "Was Emma analyzing the feedback?",
    "Was the manager holding a meeting?",
    "Was the host welcoming the guests at the door?",
    "Were they climbing the rocky hill?",
    "Were we finishing the group assignment?",
    "Were the travelers packing for their vacation?",
    "Was the artist creating a sculpture?",
    "Was the student preparing for the competition?",
    "Were the librarians rearranging the shelves?",
    "Were the kids playing hide and seek?",
    "Was the baker kneading dough for the bread?",
    "Was she helping her mother set the table?",
    "Were the engineers designing the new structure?",
    "Was the technician repairing the printer?",
    "Were the kids jumping on the trampoline?",
    "Was the guard opening the main gate?",
    "Were they waiting for the bus to arrive?",
    "Was the boat sailing across the river?",
    "Were the teachers reviewing the assignments?",
    "Was John explaining the difficult problem?",
    "Was Mike practicing the piano last night?",
    "Were the dogs running in the backyard?",
    "Was Tom driving to the office?",
    "Was Emma studying for her final exam?",
    "Were the students presenting their work?",
    "Were you folding the clean clothes?",
    "Was the team preparing for the big match?",
    "Was he organizing the documents for the meeting?",
    "Were the kids playing tag in the garden?",
    "Was Sarah writing her blog post?",
    "Were we enjoying the pleasant weather?",
    "Was the teacher guiding the students through the lesson?",
    "Were the actors rehearsing their lines?",
    "Was the dog chasing the squirrel in the park?",
    "Was the chef tasting the soup in the kitchen?",
    "Was the scientist conducting an experiment?",
    "Were the volunteers distributing pamphlets?",
    "Was he adjusting the lighting setup?",
    "Were you reading your emails?",
    "Was the team celebrating their success?",
    "Was the customer placing an order?",
    "Were we waiting for the next train?",
    "Was the musician tuning his guitar?",
    "Were the kids behaving themselves?",
    "Was the professor explaining the new topic?",
    "Were the artists performing at the festival?",
    "Were we cleaning the house after the party?",
    "Was the child crying for attention?",
    "Was the coach training the players?",
    "Were the students completing their assignments?",
    "Was she trying on a new dress?",
    "Were we meeting the new project manager?",
    "Was Mike sending the invitations for the event?",
    "Were the dogs barking at the delivery man?",
    "Was the staff organizing the conference?",
    "Were the tourists exploring the historic site?",
    "Was the waiter serving the dishes?",
    "Were the parents watching their kids play?",
    "Was the dog digging a hole in the yard?",
    "Was the actor practicing his monologue?",
    "Were you explaining the instructions?",
    "Was the robot cleaning the floor?",
    "Were the flowers blooming in the garden?",
    "Was the programmer debugging the code?",
    "Were they relaxing in the living room?",
    "Were we discussing the project details?",
    "Was the student answering the teacher's question?",
    "Were the neighbors moving to a new place?",
    "Was the teacher assigning homework to the class?",
    "Was the artist painting a landscape?",
    "Was the cat chasing the mouse in the kitchen?",
    "Were the players warming up for the game?",
    "Were the kids swinging on the swings?",
    "Were you painting the fence?",
    "Was the chef preparing dessert?",
    "Were the librarians stacking books?",

    };
    public HashSet<string> past_perfect_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
        "Had you finished your homework before the deadline?",
    "Had she read that book before the movie came out?",
    "Had they played football before it started raining?",
    "Had he completed his project on time?",
    "Had we cleaned the house before the guests arrived?",
    "Had the dog barked before they opened the door?",
    "Had the kids eaten their lunch before the class started?",
    "Had John fixed the car before the trip?",
    "Had my parents organized the party before the weekend?",
    "Had the teacher explained the topic before the exam?",
    "Had we helped them with the work they assigned?",
    "Had the cat slept before the kids started playing?",
    "Had Sarah written her essay before the class began?",
    "Had the students studied the material before the test?",
    "Had Alice practiced the piano before the concert?",
    "Had you washed the dishes before you left?",
    "Had Mike arranged the documents before the meeting?",
    "Had they traveled to the countryside before winter?",
    "Had Emma baked the cake before the guests arrived?",
    "Had we solved the problem before the time ran out?",
    "Had Tom painted the house before selling it?",
    "Had David taught the lesson before the semester ended?",
    "Had my cousins visited the museum during their vacation?",
    "Had the workers repaired the road before the storm hit?",
    "Had James prepared dinner before his friends came over?",
    "Had the kids built the sandcastle before the tide came in?",
    "Had the train arrived before the passengers reached the station?",
    "Had the tourists taken photographs before the sun set?",
    "Had Jack designed the poster before the event started?",
    "Had I helped you finish your assignment before the teacher asked for it?",
    "Had the manager organized the meeting before the deadline?",
    "Had the nurses treated the patients before the doctor arrived?",
    "Had the baby cried before falling asleep?",
    "Had we arranged the room before the event began?",
    "Had the gardener planted flowers before it started raining?",
    "Had the students discussed the questions before submitting their answers?",
    "Had the librarian sorted the books before the library opened?",
    "Had he solved the puzzle before everyone else?",
    "Had the musicians performed their set before the lights went out?",
    "Had Lily sketched a portrait before her art class?",
    "Had the chefs prepared the meal before the customers arrived?",
    "Had the sun set before they reached the top of the hill?",
    "Had the carpenter built the table before the furniture expo?",
    "Had the kids ridden their bikes before the rain started?",
    "Had you watered the plants before the heatwave?",
    "Had we explored the park before it got crowded?",
    "Had the teacher checked the homework before the lesson?",
    "Had they fed the animals before the visitors came?",
    "Had the baby slept peacefully before waking up?",
    "Had my neighbors invited their friends before the barbecue?",
    "Had Alice sewn the dress before the wedding?",
    "Had Emma designed the website before the launch day?",
    "Had the students revised the notes before the presentation?",
    "Had Sarah explained the rules before the game began?",
    "Had the birds flown away before the storm?",
    "Had he learned to drive before his vacation?",
    "Had I improved my skills before the competition?",
    "Had the software updated automatically before the issue occurred?",
    "Had the doctor treated the patient before the shift ended?",
    "Had the organizers planned the seminar before the participants arrived?",
    "Had you repaired the fence before the inspection?",
    "Had the team practiced enough before the final match?",
    "Had Mike ironed his clothes before going out?",
    "Had we planted flowers before spring arrived?",
    "Had John painted the portrait before the deadline?",
    "Had the children arranged their books before the teacher came in?",
    "Had Tom collected the tickets before the train departed?",
    "Had Lily polished the silverware before dinner?",
    "Had we dusted the furniture before the guests arrived?",
    "Had the computer processed the data before the deadline?",
    "Had the workers built the structure before the inspection?",
    "Had the kids drawn pictures before their art class?",
    "Had Sarah rehearsed her lines before the play?",
    "Had the pianist performed the final piece before the curtain closed?",
    "Had they brainstormed ideas before the meeting started?",
    "Had the family decorated the Christmas tree before the holiday?",
    "Had the director discussed the agenda before the team meeting?",
    "Had we organized the files before the audit?",
    "Had Emma analyzed the data before submitting the report?",
    "Had the manager held the meeting before the schedule change?",
    "Had the host welcomed the guests before dinner?",
    "Had they climbed the hill before the rain started?",
    "Had we finished the assignment before the deadline?",
    "Had the travelers packed their bags before the trip?",
    "Had the artist created the sculpture before the exhibition?",
    "Had the student prepared the project before the submission deadline?",
    "Had the librarians rearranged the bookshelves before opening?",
    "Had the kids played board games before going to bed?",
    "Had the baker kneaded the dough before baking the bread?",
    "Had she helped her mother before the guests arrived?",
    "Had the engineers designed the plan before the meeting?",
    "Had the technician repaired the device before the users arrived?",
    "Had the kids jumped on the trampoline before dinner?",
    "Had the guard opened the gate before the shift ended?",
    "Had they waited for the bus before deciding to walk?",
    "Had the boat sailed before the sun came up?",
    "Had the teachers reviewed the essays before grading them?",
    "Had John explained the question before giving the answer?",
    "Had Mike practiced the piano before the recital?",
    "Had the dogs run around before settling down?",
    "Had Tom driven to the store before the sale ended?",
    "Had Emma studied the notes before the test?",
    "Had the students delivered their presentations before the class ended?",
    "Had you folded the clothes before leaving?",
    "Had the team practiced enough before the final round?",
    "Had he organized the papers before the meeting?",
    "Had the kids played hide and seek before dinner?",
    "Had Sarah written her diary before going to bed?",
    "Had we enjoyed the music before the concert ended?",
    "Had the teacher guided the students before the exam?",
    "Had the actors rehearsed their parts before the audience arrived?",
    "Had the dog chased the squirrel before getting tired?",
    "Had the chef tasted the soup before serving it?",
    "Had the scientist conducted the experiment before publishing the paper?",
    "Had the volunteers distributed the leaflets before the event?",
    "Had he adjusted the settings before starting the system?",
    "Had you read your emails before the meeting?",
    "Had the team celebrated their success before leaving?",
    "Had the customer placed the order before the store closed?",
    "Had we waited long before the announcement?",
    "Had the musician tuned the guitar before performing?",
    "Had the kids behaved well before their parents arrived?",
    "Had the professor explained the topic before moving on?",
    "Had the artists performed before the lights went out?",
    "Had we cleaned the house before the guests came?",
    "Had the child cried before getting the candy?",
    "Had the coach trained the players before the game?",
    "Had the students completed their work before leaving school?",
    "Had she tried the new recipe before sharing it?",
    "Had we met the manager before the meeting?",
    "Had Mike sent the invitations before the deadline?",
    "Had the dogs barked before the stranger left?",
    "Had the staff organized the room before the meeting?",
    "Had the tourists explored the site before taking pictures?",
    "Had the waiter served the food before the guests arrived?",
    "Had the parents watched the kids before going out?",
    "Had the dog dug a hole before the rain?",
    "Had the actor practiced the lines before the scene?",
    "Had you explained the steps before the task began?",
    "Had the robot cleaned the floor before the demonstration?",
    "Had the flowers bloomed before the photo shoot?",
    "Had the programmer fixed the error before testing?",
    "Had they relaxed before the journey began?",
    "Had we discussed the topic before the presentation?",
    "Had the student answered the question before the teacher moved on?",
    "Had the neighbors moved to the new house before the end of the month?",
    "Had the teacher assigned the work before the bell rang?",
    "Had the artist painted the scenery before the exhibition?",
    "Had the cat chased the mouse before hiding?",
    "Had the players warmed up before the match?",
    "Had the kids swung on the swings before leaving the park?",
    "Had you painted the wall before decorating it?",
    "Had the chef prepared dessert before the dinner?"
    };
    public HashSet<string> past_perfect_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "Had you been studying for the test before the class started?",
    "Had she been reading that book before the library closed?",
    "Had they been playing football before it began to rain?",
    "Had he been working on his project before it was submitted?",
    "Had we been cleaning the house before the guests arrived?",
    "Had the dog been barking all night before they checked the yard?",
    "Had the kids been playing in the park before it got dark?",
    "Had John been fixing the car before the trip began?",
    "Had my parents been organizing the party before the weekend?",
    "Had the teacher been explaining the lesson before the exam started?",
    "Had we been helping him with his work before he asked for more?",
    "Had the cat been sleeping on the couch before the kids woke it up?",
    "Had Sarah been writing her essay before the deadline?",
    "Had the students been studying for the exam all week?",
    "Had Alice been practicing the piano before the recital?",
    "Had you been washing the dishes before we arrived?",
    "Had Mike been arranging the files before the meeting started?",
    "Had they been traveling to the city before the storm hit?",
    "Had Emma been baking a cake before the party started?",
    "Had we been solving puzzles before the session ended?",
    "Had Tom been painting the fence before it started raining?",
    "Had David been teaching English before the semester ended?",
    "Had my cousins been visiting the museum during their vacation?",
    "Had the workers been repairing the bridge before the traffic resumed?",
    "Had James been preparing dinner before his friends came over?",
    "Had the kids been building a sandcastle before the tide came in?",
    "Had the train been running late before the schedule was fixed?",
    "Had the tourists been taking pictures before the weather changed?",
    "Had Jack been designing the poster before the presentation started?",
    "Had I been helping him with the assignment before the submission?",
    "Had the manager been organizing the meeting before the big presentation?",
    "Had the nurses been treating patients before the doctor arrived?",
    "Had the baby been crying before they comforted her?",
    "Had we been arranging the chairs before the conference started?",
    "Had the gardener been planting flowers before the rain came?",
    "Had the students been discussing the project before the teacher arrived?",
    "Had the librarian been sorting the books before the library opened?",
    "Had he been solving a difficult puzzle before we interrupted him?",
    "Had the musicians been performing on stage before the power outage?",
    "Had Lily been sketching a portrait before the art class?",
    "Had the chefs been preparing the food before the guests arrived?",
    "Had the sun been setting before they took the photo?",
    "Had the carpenter been building furniture before the expo started?",
    "Had the kids been riding bikes before the storm began?",
    "Had you been watering the plants before the heatwave started?",
    "Had we been exploring the area before the maps arrived?",
    "Had the teacher been checking homework before the students submitted it?",
    "Had they been feeding the animals before the visitors arrived?",
    "Had the baby been sleeping peacefully before the noise woke her up?",
    "Had my neighbors been inviting guests before they planned the event?",
    "Had Alice been sewing her dress before the deadline?",
    "Had Emma been designing the website before the product launch?",
    "Had the students been revising for their exams before the bell rang?",
    "Had Sarah been explaining the instructions before the team started working?",
    "Had the birds been flying across the field before the storm started?",
    "Had he been learning to play the guitar before joining the band?",
    "Had I been improving my skills before the big test?",
    "Had the software been updating before the glitch occurred?",
    "Had the doctor been treating the patients before the nurses arrived?",
    "Had the organizers been planning the event before the sponsors confirmed?",
    "Had you been repairing the old bike before selling it?",
    "Had the team been practicing for the championship before the game?",
    "Had Mike been ironing his shirts before the trip?",
    "Had we been planting trees before the initiative started?",
    "Had John been painting portraits before the exhibition?",
    "Had the children been arranging the chairs before the parents arrived?",
    "Had Tom been collecting tickets before the gate opened?",
    "Had Lily been polishing the cutlery before the dinner?",
    "Had we been cleaning the house before the guests arrived?",
    "Had the computer been processing the data before the crash?",
    "Had the workers been building the structure before the inspection?",
    "Had the kids been drawing pictures before the competition?",
    "Had Sarah been rehearsing her lines before the play?",
    "Had the pianist been practicing before the performance?",
    "Had they been brainstorming ideas before the workshop?",
    "Had the family been decorating the Christmas tree before the event?",
    "Had the director been discussing the agenda before the meeting?",
    "Had we been organizing the files before the audit?",
    "Had Emma been analyzing the data before the report?",
    "Had the manager been holding the meeting before the schedule changed?",
    "Had the host been welcoming the guests before the event started?",
    "Had they been climbing the mountain before the storm started?",
    "Had we been finishing the project before the deadline?",
    "Had the travelers been packing for their journey before the taxi arrived?",
    "Had the artist been creating the sculpture before the exhibition?",
    "Had the student been preparing the project before the submission?",
    "Had the librarians been rearranging the shelves before opening time?",
    "Had the kids been playing games before it was time to leave?",
    "Had the baker been kneading dough before baking the bread?",
    "Had she been helping her mom with chores before relaxing?",
    "Had the engineers been designing the bridge before the storm?",
    "Had the technician been repairing the machine before the users arrived?",
    "Had the kids been jumping on the trampoline before dinner?",
    "Had the guard been opening the gate before their shift ended?",
    "Had they been waiting for the bus before walking home?",
    "Had the boat been sailing before the weather got rough?",
    "Had the teachers been reviewing the assignments before the report cards?",
    "Had John been explaining the problem before the lesson ended?",
    "Had Mike been practicing the piano before the concert?",
    "Had the dogs been running around the park before being leashed?",
    "Had Tom been driving to the store before the rain began?",
    "Had Emma been studying before the quiz?",
    "Had the students been delivering their projects before the final bell?",
    "Had you been folding the laundry before heading out?",
    "Had the team been preparing for the finals before the fans arrived?",
    "Had he been organizing the documents before the team meeting?",
    "Had the kids been playing hide-and-seek before the bell rang?",
    "Had Sarah been writing in her diary before going to bed?",
    "Had we been enjoying the meal before the power went out?",
    "Had the teacher been guiding the students before the principal arrived?",
    "Had the actors been rehearsing before the play opened?",
    "Had the dog been chasing the ball before taking a rest?",
    "Had the chef been tasting the soup before serving it?",
    "Had the scientist been conducting experiments before publishing?",
    "Had the volunteers been distributing flyers before the event?",
    "Had he been adjusting the camera before the photo shoot?",
    "Had you been reading emails before the presentation?",
    "Had the team been celebrating their success before the interview?",
    "Had the customer been placing orders before the shop closed?",
    "Had we been waiting for the announcement before the speaker arrived?",
    "Had the musician been tuning their guitar before playing?",
    "Had the kids been behaving well before their parents arrived?",
    "Had the professor been explaining the topic before the break?",
    "Had the artists been performing before the stage lights went out?",
    "Had we been cleaning the house before the visitors arrived?",
    "Had the child been crying before being comforted?",
    "Had the coach been training the players before the tournament?",
    "Had the students been completing their assignments before the exam?",
    "Had she been trying a new dish before sharing it?",
    "Had we been meeting with the organizer before the event started?",
    "Had Mike been sending invitations before the party?",
    "Had the dogs been barking before the owners came out?",
    "Had the staff been organizing the event before the guests arrived?",
    "Had the tourists been exploring the monument before the guide arrived?",
    "Had the waiter been serving drinks before the food was ready?",
    "Had the parents been watching their children before leaving?",
    "Had the dog been digging before they called it inside?",
    "Had the actor been practicing his script before the show?",
    "Had you been explaining the task before the team started?",
    "Had the robot been cleaning the floor before the trial?",
    "Had the flowers been blooming before the frost?",
    "Had the programmer been debugging the software before the update?",
    "Had they been relaxing before the journey started?",
    "Had we been discussing the topic before writing the report?",
    "Had the student been answering questions before the teacher moved on?",
    "Had the neighbors been moving their belongings before the movers arrived?",
    "Had the teacher been assigning projects before explaining them?",
    "Had the artist been painting the canvas before selling it?",
    "Had the cat been chasing the mouse before resting?",
    "Had the players been warming up before the match started?",
    "Had the kids been swinging on the swings before it began to rain?",
    "Had you been painting the walls before the renovation started?",
    "Had the chef been preparing dessert before the guests arrived?",
    "Had the librarians been stacking books before the library opened?",
    "Had the bakers been decorating the cakes before the bakery opened?",
    "Had the singer been practicing her new song before the performance?",
    "Had the parents been watching their children before the teacher arrived?",
    "Had the dog been digging in the garden before the rain started?",
    "Had the actor been practicing his lines before the audition?",
    "Had you been explaining the project before the team started working?",
    "Had the robot been cleaning the floor before the demonstration?",
    "Had the flowers been blooming before the frost came?",
    "Had the programmer been debugging the software before the deadline?",
    "Had they been relaxing before the journey started?",
    "Had we been discussing the details before signing the contract?",
    "Had the student been answering questions before the test started?",
    "Had the neighbors been moving into their new house before we visited?",
    "Had the teacher been assigning projects before the bell rang?",
    "Had the artist been painting the mural before the unveiling event?",
    "Had the cat been chasing the mouse before it got tired?",
    "Had the players been warming up before the championship match?",
    "Had the kids been jumping on the trampoline before dinner?",
    "Had the gardeners been planting new flowers before the festival?",
    "Had the chef been preparing a new dish before the guests arrived?",
    "Had the librarian been rearranging books before the inspection?",
    "Had the engineer been designing the new building before the meeting?",
    "Had the workers been repairing the road before the traffic returned?",
    "Had the scientist been conducting experiments before publishing the results?",
    "Had the musician been tuning her instrument before the concert started?",
    "Had the children been singing songs before the recital began?",
    "Had the chef been tasting the soup before it was served?",
    "Had the volunteers been organizing the event before the sponsors arrived?",
    "Had the professor been explaining the topic before the students asked questions?",
    "Had the students been completing their essays before the submission time?",
    "Had the doctor been treating patients before the hospital reopened?",
    "Had the tourists been exploring the historic sites before the storm started?",
    "Had the team been brainstorming ideas before the project kickoff?",
    "Had the dog been barking at strangers before they left?",
    "Had the parents been helping their children before bedtime?",
    "Had the actor been rehearsing for the movie before it started filming?",
    "Had the coach been training the players before the big game?",
    "Had the kids been drawing pictures before showing them to the teacher?",
    "Had the librarian been organizing the shelves before the new arrivals?",
    "Had the artist been creating sculptures before presenting them at the gallery?",
    "Had the travelers been packing their bags before the taxi arrived?",
    "Had the teacher been correcting assignments before the report cards?",
    "Had the host been welcoming guests before the party began?",
    "Had the manager been preparing for the meeting before the client arrived?",
    "Had the workers been cleaning the site before the inspection team arrived?",
    "Had the hikers been climbing the mountain before the snow started?",
    "Had the writer been editing her novel before submitting it?",
    "Had the photographer been capturing landscapes before the exhibition?",
    "Had the designer been finalizing the outfit before the fashion show?",
    "Had the builder been constructing the bridge before the flood warnings?",
    "Had the nurse been assisting patients before the shift ended?",
    "Had the event planner been coordinating activities before the guests arrived?",
    "Had the students been researching their projects before the seminar?",
    "Had the kids been playing tag before the school bell rang?",
    "Had the researchers been analyzing data before publishing the study?",
    "Had the shop owner been arranging products before the customers arrived?",
    "Had the chef been experimenting with recipes before deciding on the menu?",
    "Had the neighbors been preparing their garden before the festival?",
    "Had the scientist been testing the equipment before the experiment?"
    };

    public HashSet<string> future_simple_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
    "Will you read that book tomorrow?",
    "Will she watch the movie tonight?",
    "Will they play football this weekend?",
    "Will he complete his homework before the deadline?",
    "Will we clean the house before the guests arrive?",
    "Will the dog bark at strangers?",
    "Will the kids play in the park after school?",
    "Will John fix the car tomorrow?",
    "Will my parents organize the party next week?",
    "Will the teacher explain the topic in the next class?",
    "Will we help them with the assignment later?",
    "Will the cat sleep on the couch tonight?",
    "Will Sarah write a story for her class?",
    "Will the students study for the upcoming test?",
    "Will Alice practice the piano this evening?",
    "Will you wash the dishes after dinner?",
    "Will Mike arrange the documents before the meeting?",
    "Will they travel to the countryside next month?",
    "Will Emma bake a cake for the party?",
    "Will we solve the puzzle together later?",
    "Will Tom paint the fence this weekend?",
    "Will David teach English in the next semester?",
    "Will my cousins visit the museum during their trip?",
    "Will the workers repair the bridge by next week?",
    "Will James prepare dinner for his family?",
    "Will the kids build a sandcastle at the beach?",
    "Will the train arrive on time tomorrow?",
    "Will the tourists take pictures during the tour?",
    "Will Jack design the poster for the event?",
    "Will I help you with your project later?",
    "Will the manager organize the meeting next Monday?",
    "Will the nurses treat the patients efficiently?",
    "Will the baby cry if left alone?",
    "Will we arrange the chairs before the event starts?",
    "Will the gardener plant flowers in the new garden?",
    "Will the students discuss their project tomorrow?",
    "Will the librarian sort the books in the morning?",
    "Will he solve the puzzle before the time runs out?",
    "Will the musicians perform on stage tonight?",
    "Will Lily sketch a portrait for her art class?",
    "Will the chefs prepare the meals before the dinner rush?",
    "Will the sun set early tomorrow evening?",
    "Will the carpenter build furniture for the new house?",
    "Will the kids ride their bikes in the park?",
    "Will you water the plants in the garden later?",
    "Will we explore the park next weekend?",
    "Will the teacher check the homework tomorrow?",
    "Will they feed the animals at the zoo?",
    "Will the baby sleep peacefully through the night?",
    "Will my neighbors invite us over for dinner?",
    "Will Alice sew a dress for the wedding?",
    "Will Emma design the website for the company?",
    "Will the students revise their notes before the exam?",
    "Will Sarah explain the instructions to her team?",
    "Will the birds fly south for the winter?",
    "Will he learn to play the guitar this year?",
    "Will I improve my skills during the course?",
    "Will the software update automatically overnight?",
    "Will the doctor treat the patient promptly?",
    "Will the organizers plan the event successfully?",
    "Will you repair the broken chair?",
    "Will the team practice for the match tomorrow?",
    "Will Mike iron his clothes for the meeting?",
    "Will we plant flowers in the garden this spring?",
    "Will John paint a new masterpiece for the gallery?",
    "Will the children arrange their toys before bedtime?",
    "Will Tom collect tickets at the counter?",
    "Will Lily polish the silverware before the dinner?",
    "Will we dust the furniture tomorrow morning?",
    "Will the computer process the data efficiently?",
    "Will the workers build the new office by next month?",
    "Will the kids draw pictures during art class?",
    "Will Sarah rehearse her lines before the show?",
    "Will the pianist perform a new piece at the concert?",
    "Will they brainstorm ideas for the project?",
    "Will the family decorate the Christmas tree together?",
    "Will the director discuss the agenda in the meeting?",
    "Will we organize the files before the audit?",
    "Will Emma analyze the feedback after the presentation?",
    "Will the manager hold a team meeting tomorrow?",
    "Will the host welcome the guests warmly?",
    "Will they climb the mountain next summer?",
    "Will we finish the assignment by the deadline?",
    "Will the travelers pack their bags tonight?",
    "Will the artist create a sculpture for the exhibition?",
    "Will the student prepare a project for the competition?",
    "Will the librarians rearrange the shelves this week?",
    "Will the kids play board games after dinner?",
    "Will the baker knead the dough for fresh bread?",
    "Will she help her mother prepare for the party?",
    "Will the engineers design a new structure for the bridge?",
    "Will the technician repair the printer by tomorrow?",
    "Will the kids jump on the trampoline later?",
    "Will the guard open the gate for visitors?",
    "Will they wait for the bus at the station?",
    "Will the boat sail across the lake?",
    "Will the teachers review the essays before grading?",
    "Will John explain the solution to the problem?",
    "Will Mike practice the piano for the performance?",
    "Will the dogs run in the yard this afternoon?",
    "Will Tom drive to the city next week?",
    "Will Emma study for her test tomorrow?",
    "Will the students deliver their projects on time?",
    "Will you fold the clothes after washing them?",
    "Will the team prepare for the finals this weekend?",
    "Will he organize the documents for the client?",
    "Will the kids play hide and seek after dinner?",
    "Will Sarah write in her journal before bed?",
    "Will we enjoy the music at the concert?",
    "Will the teacher guide the students during the trip?",
    "Will the actors rehearse for the play tomorrow?",
    "Will the dog chase the cat in the yard?",
    "Will the chef taste the soup before serving it?",
    "Will the scientist conduct an experiment in the lab?",
    "Will the volunteers distribute flyers for the event?",
    "Will he adjust the settings on the device?",
    "Will you read your emails before the meeting?",
    "Will the team celebrate their victory tomorrow?",
    "Will the customer place an order online?",
    "Will we wait for the announcement before proceeding?",
    "Will the musician tune the guitar before the concert?",
    "Will the kids behave well during the trip?",
    "Will the professor explain the topic in class?",
    "Will the artists perform at the festival next weekend?",
    "Will we clean the house before the guests arrive?",
    "Will the child cry during the vaccination?",
    "Will the coach train the players for the championship?",
    "Will the students complete their assignments on time?",
    "Will she try a new recipe for the dinner party?",
    "Will we meet the project manager tomorrow?",
    "Will Mike send the invitations by email?",
    "Will the dogs bark at strangers near the house?",
    "Will the staff organize the room for the seminar?",
    "Will the tourists explore the museum tomorrow?",
    "Will the waiter serve drinks to the guests?",
    "Will the parents watch their kids at the park?",
    "Will the dog dig a hole in the garden?",
    "Will the actor practice his lines for the show?",
    "Will you explain the rules before the game starts?",
    "Will the robot clean the floor after the demonstration?",
    "Will the flowers bloom in the spring?",
    "Will the programmer debug the software before the release?",
    "Will they relax after the meeting ends?",
    "Will we discuss the project during the meeting?",
    "Will the student answer the teacher's question?",
    "Will the neighbors move to their new house soon?",
    "Will the teacher assign homework for the weekend?",
    "Will the artist paint a landscape for the gallery?",
    "Will the cat chase the mouse in the kitchen?",
    "Will the players warm up before the match?",
    "Will the kids swing on the swings at the park?",
    "Will you paint the walls of your new house?",



    };
    public HashSet<string> future_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {

         "Will you be reading that book tomorrow?",
    "Will she be watching the movie tonight?",
    "Will they be playing football this weekend?",
    "Will he be working on his project this evening?",
    "Will we be cleaning the house before the guests arrive?",
    "Will the dog be barking all night again?",
    "Will the kids be playing in the park after school?",
    "Will John be fixing the car in the morning?",
    "Will my parents be organizing the party next weekend?",
    "Will the teacher be explaining the topic in the next class?",
    "Will we be helping them with their homework later?",
    "Will the cat be sleeping on the couch tonight?",
    "Will Sarah be writing a story for her class?",
    "Will the students be studying for their exams tomorrow?",
    "Will Alice be practicing the piano in the evening?",
    "Will you be washing the dishes after dinner?",
    "Will Mike be arranging the files before the meeting?",
    "Will they be traveling to the countryside during the holidays?",
    "Will Emma be baking a cake for the celebration?",
    "Will we be solving puzzles together later?",
    "Will Tom be painting the fence this weekend?",
    "Will David be teaching English in the afternoon?",
    "Will my cousins be visiting the museum tomorrow?",
    "Will the workers be repairing the bridge by next week?",
    "Will James be preparing dinner for his family tonight?",
    "Will the kids be building a sandcastle at the beach?",
    "Will the train be arriving on time later today?",
    "Will the tourists be taking pictures during the tour?",
    "Will Jack be designing a poster for the event?",
    "Will I be helping you with the project later?",
    "Will the manager be organizing the meeting on Monday?",
    "Will the nurses be treating the patients effectively?",
    "Will the baby be crying during the ceremony?",
    "Will we be arranging the chairs for the meeting?",
    "Will the gardener be planting flowers in the garden this afternoon?",
    "Will the students be discussing their project tomorrow?",
    "Will the librarian be sorting the books in the morning?",
    "Will he be solving a puzzle in the competition?",
    "Will the musicians be performing on stage tonight?",
    "Will Lily be sketching a portrait for her art class?",
    "Will the chefs be preparing meals for the event?",
    "Will the sun be setting earlier tomorrow?",
    "Will the carpenter be building furniture for the new house?",
    "Will the kids be riding their bikes in the park later?",
    "Will you be watering the plants in the evening?",
    "Will we be exploring the park during the weekend?",
    "Will the teacher be checking homework tomorrow?",
    "Will they be feeding the animals at the farm?",
    "Will the baby be sleeping peacefully during the flight?",
    "Will my neighbors be inviting guests for dinner tomorrow?",
    "Will Alice be sewing a dress for the wedding?",
    "Will Emma be designing a website for her client?",
    "Will the students be revising for their tests this week?",
    "Will Sarah be explaining the assignment to her group?",
    "Will the birds be flying south for the winter?",
    "Will he be learning how to drive this summer?",
    "Will I be improving my skills at the workshop?",
    "Will the software be updating overnight?",
    "Will the doctor be treating patients at the clinic?",
    "Will the organizers be planning the seminar for next month?",
    "Will you be repairing the broken chair?",
    "Will the team be practicing for the finals tomorrow?",
    "Will Mike be ironing his clothes for the meeting?",
    "Will we be planting trees in the garden next spring?",
    "Will John be painting a masterpiece for the exhibition?",
    "Will the children be arranging their toys after playtime?",
    "Will Tom be collecting tickets at the counter?",
    "Will Lily be polishing the silverware for the banquet?",
    "Will we be dusting the furniture tomorrow?",
    "Will the computer be processing the data all night?",
    "Will the workers be building the new office by the end of the month?",
    "Will the kids be drawing pictures in art class?",
    "Will Sarah be rehearsing her lines for the play?",
    "Will the pianist be performing a new piece at the concert?",
    "Will they be brainstorming ideas during the session?",
    "Will the family be decorating the Christmas tree together?",
    "Will the director be discussing the plans during the meeting?",
    "Will we be organizing the reports before the deadline?",
    "Will Emma be analyzing the feedback after the presentation?",
    "Will the manager be holding a meeting with the team tomorrow?",
    "Will the host be welcoming guests at the party?",
    "Will they be climbing the mountain during their trip?",
    "Will we be finishing our projects before the deadline?",
    "Will the travelers be packing their bags this evening?",
    "Will the artist be creating a sculpture for the gallery?",
    "Will the student be preparing a project for the competition?",
    "Will the librarians be rearranging the shelves tomorrow morning?",
    "Will the kids be playing board games after dinner?",
    "Will the baker be kneading dough for fresh bread?",
    "Will she be helping her mom in the kitchen this evening?",
    "Will the engineers be designing a new bridge for the city?",
    "Will the technician be repairing the printer this afternoon?",
    "Will the kids be jumping on the trampoline after school?",
    "Will the guard be opening the gate for visitors?",
    "Will they be waiting for the bus at the station?",
    "Will the boat be sailing across the lake tomorrow?",
    "Will the teachers be reviewing essays before submitting the grades?",
    "Will John be explaining the solution during the class?",
    "Will Mike be practicing the piano before the show?",
    "Will the dogs be running in the park in the morning?",
    "Will Tom be driving to work tomorrow?",
    "Will Emma be studying for her test tomorrow evening?",
    "Will the students be delivering their presentations next week?",
    "Will you be folding clothes after doing the laundry?",
    "Will the team be preparing for the match on Saturday?",
    "Will he be organizing documents for the meeting later?",
    "Will the kids be playing hide-and-seek after dinner?",
    "Will Sarah be writing in her journal at night?",
    "Will we be enjoying the concert this weekend?",
    "Will the teacher be guiding the students on their trip?",
    "Will the actors be rehearsing their roles tomorrow?",
    "Will the dog be chasing the ball in the yard?",
    "Will the chef be tasting the soup before serving it?",
    "Will the scientist be conducting experiments in the lab?",
    "Will the volunteers be distributing flyers for the event?",
    "Will he be adjusting the settings on the device?",
    "Will you be checking your emails tomorrow morning?",
    "Will the team be celebrating their victory tomorrow?",
    "Will the customer be placing an order online?",
    "Will we be waiting for the announcement before taking action?",
    "Will the musician be tuning his guitar before the performance?",
    "Will the kids be behaving well during the field trip?",
    "Will the professor be explaining new concepts in the next lecture?",
    "Will the artists be performing at the cultural event?",
    "Will we be cleaning the house before the party starts?",
    "Will the child be crying during the vaccination session?",
    "Will the coach be training the players for the tournament?",
    "Will the students be completing their assignments on time?",
    "Will she be trying a new recipe for the dinner party?",
    "Will we be meeting the project manager later?",
    "Will Mike be sending the invitations before the event?",
    "Will the dogs be barking at strangers near the house?",
    "Will the staff be organizing the room for the seminar tomorrow?",
    "Will the tourists be exploring the museum during the tour?",
    "Will the waiter be serving drinks at the reception?",
    "Will the parents be watching their children play in the park?",
    "Will the dog be digging holes in the garden?",
    "Will the actor be practicing his lines before the show?",
    "Will you be explaining the game rules to the players?",
    "Will the robot be cleaning the floor during the demonstration?",
    "Will the flowers be blooming next spring?",
    "Will the programmer be debugging software before the launch?",
    "Will they be relaxing after the meeting ends?",
    "Will we be discussing the project during the team meeting?",
    "Will the student be answering questions in the next session?",
    "Will the neighbors be moving into their new house next week?",
    "Will the teacher be assigning homework before the holidays?",
    "Will the artist be painting a landscape for the exhibit?",
    "Will the cat be chasing the mouse in the yard?",
    "Will the players be warming up before the big game?",
    "Will the kids be swinging on the swings at the park?",
    "Will you be painting the walls in the new house?",
    "Will the chef be preparing a special dessert for the dinner party?"
    };
    public HashSet<string> future_perfect_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
       "Will you have finished your homework by tomorrow?",
    "Will she have read that book by the end of the week?",
    "Will they have played football by noon?",
    "Will he have completed his project by the deadline?",
    "Will we have cleaned the house before the guests arrive?",
    "Will the dog have barked at strangers by then?",
    "Will the kids have played in the park before it gets dark?",
    "Will John have fixed the car by the weekend?",
    "Will my parents have organized the party by next week?",
    "Will the teacher have explained the topic before the test starts?",
    "Will we have helped them with the assignment by the evening?",
    "Will the cat have slept on the couch before dinner?",
    "Will Sarah have written her essay before the meeting?",
    "Will the students have studied the material before the exam?",
    "Will Alice have practiced the piano before the concert?",
    "Will you have washed the dishes before the guests arrive?",
    "Will Mike have arranged the documents before the presentation?",
    "Will they have traveled to the city by the weekend?",
    "Will Emma have baked the cake by the time the guests arrive?",
    "Will we have solved the puzzle by the time the competition ends?",
    "Will Tom have painted the fence before the rain starts?",
    "Will David have taught this lesson by the end of the month?",
    "Will my cousins have visited the museum by next Friday?",
    "Will the workers have repaired the road by the morning?",
    "Will James have prepared dinner for his friends by the evening?",
    "Will the kids have built the sandcastle before the tide comes in?",
    "Will the train have arrived before the commuters reach the station?",
    "Will the tourists have taken pictures before the tour ends?",
    "Will Jack have designed the poster for the event by tomorrow?",
    "Will I have helped you with your project before the deadline?",
    "Will the manager have organized the meeting before the report is due?",
    "Will the nurses have treated the patients by the end of the shift?",
    "Will the baby have cried before falling asleep?",
    "Will we have arranged the chairs for the event before the guests arrive?",
    "Will the gardener have planted flowers in the garden by summer?",
    "Will the students have discussed their projects before the presentation?",
    "Will the librarian have sorted the books by opening time?",
    "Will he have solved the puzzle before everyone else?",
    "Will the musicians have performed on stage by midnight?",
    "Will Lily have sketched her masterpiece by the weekend?",
    "Will the chefs have prepared the meals before the event starts?",
    "Will the sun have set before they reach the hilltop?",
    "Will the carpenter have built the furniture by tomorrow?",
    "Will the kids have ridden their bikes by lunchtime?",
    "Will you have watered the plants by the evening?",
    "Will we have explored the park before the guide arrives?",
    "Will the teacher have checked all the homework by the morning?",
    "Will they have fed the animals before the visitors arrive?",
    "Will the baby have slept peacefully by the time the flight lands?",
    "Will my neighbors have invited their friends for dinner by the weekend?",
    "Will Alice have sewn her dress by the time of the event?",
    "Will Emma have designed the website by the product launch?",
    "Will the students have revised their notes before the test starts?",
    "Will Sarah have explained the instructions to her classmates by the afternoon?",
    "Will the birds have flown south for the winter by December?",
    "Will he have learned the guitar by the end of the year?",
    "Will I have improved my skills by the next competition?",
    "Will the software have updated automatically before the start of the session?",
    "Will the doctor have treated all patients by the end of the day?",
    "Will the organizers have planned the seminar by the beginning of the week?",
    "Will you have repaired the chair by the time they arrive?",
    "Will the team have practiced enough by the championship match?",
    "Will Mike have ironed his shirt before leaving for the meeting?",
    "Will we have planted flowers in the garden by the beginning of spring?",
    "Will John have painted his masterpiece by the art exhibition?",
    "Will the children have arranged their toys before bedtime?",
    "Will Tom have collected all the tickets before the event starts?",
    "Will Lily have polished the silverware before the banquet?",
    "Will we have dusted the furniture by the time the guests come?",
    "Will the computer have processed all the data by the deadline?",
    "Will the workers have built the new office by the end of the year?",
    "Will the kids have drawn their pictures for the art competition?",
    "Will Sarah have rehearsed her lines by the beginning of the play?",
    "Will the pianist have performed the final piece by the end of the concert?",
    "Will they have brainstormed ideas by the time the meeting starts?",
    "Will the family have decorated the Christmas tree by Christmas Eve?",
    "Will the director have discussed the agenda before the board meeting?",
    "Will we have organized the reports before the auditors arrive?",
    "Will Emma have analyzed the results before the presentation?",
    "Will the manager have held a meeting with the team by next Monday?",
    "Will the host have welcomed the guests by the time dinner is served?",
    "Will they have climbed the mountain before the storm begins?",
    "Will we have finished the group project by the end of the week?",
    "Will the travelers have packed their luggage by the morning?",
    "Will the artist have created a sculpture for the exhibition?",
    "Will the student have prepared her project before the submission deadline?",
    "Will the librarians have rearranged the shelves before the library opens?",
    "Will the kids have played all their games by the end of recess?",
    "Will the baker have kneaded the dough before the bakery opens?",
    "Will she have helped her mother prepare the dishes by the evening?",
    "Will the engineers have designed the bridge before the city inspection?",
    "Will the technician have repaired the printer before the office opens?",
    "Will the kids have jumped on the trampoline by the time dinner is ready?",
    "Will the guard have opened the gates before the visitors arrive?",
    "Will they have waited for the bus by the time it arrives?",
    "Will the boat have sailed across the lake by morning?",
    "Will the teachers have reviewed the essays before the end of the term?",
    "Will John have explained the problem to the class by tomorrow?",
    "Will Mike have practiced the piano before his recital?",
    "Will the dogs have run in the park before lunchtime?",
    "Will Tom have driven to the city by the weekend?",
    "Will Emma have studied all her notes before the exam starts?",
    "Will the students have delivered their presentations before the session ends?",
    "Will you have folded all the laundry by the time the guests arrive?",
    "Will the team have prepared for the finals before the big match?",
    "Will he have organized the documents before the client arrives?",
    "Will the kids have played all the games before bedtime?",
    "Will Sarah have written her journal entry before going to bed?",
    "Will we have enjoyed the meal by the time the music starts?",
    "Will the teacher have guided the students before the project begins?",
    "Will the actors have rehearsed their parts before the performance?",
    "Will the dog have chased the ball by the time it gets dark?",
    "Will the chef have tasted the soup before serving it?",
    "Will the scientist have conducted all experiments before publishing the results?",
    "Will the volunteers have distributed all the flyers before the event begins?",
    "Will he have adjusted the settings before starting the program?",
    "Will you have read all your emails by the beginning of the meeting?",
    "Will the team have celebrated their win by the time the media arrives?",
    "Will the customer have placed all orders before the store closes?",
    "Will we have waited for the bus for an hour by the time it arrives?",
    "Will the musician have tuned the guitar before the concert starts?",
    "Will the kids have behaved well by the time their parents return?",
    "Will the professor have explained the topic by the end of the lecture?",
    "Will the artists have performed their pieces by the end of the festival?",
    "Will we have cleaned the house before the guests arrive?",
    "Will the child have cried enough to sleep by then?",
    "Will the coach have trained the players for the tournament by next week?",
    "Will the students have completed their homework before the weekend?",
    "Will she have tried the recipe before presenting it to her family?",
    "Will we have met the new manager by the end of the day?",
    "Will Mike have sent out the invitations before the event?",
    "Will the dogs have barked enough to alert the neighbors?",
    "Will the staff have organized the seminar by tomorrow morning?",
    "Will the tourists have explored all the exhibits by the end of the day?",
    "Will the waiter have served all drinks by the time dinner is ready?",
    "Will the parents have watched their kids play before leaving?",
    "Will the dog have dug enough holes by the time it's called back?",
    "Will the actor have practiced his lines by the time the scene begins?",
    "Will you have explained the rules before the game starts?",
    "Will the robot have cleaned the floor by the end of the demonstration?",
    "Will the flowers have bloomed before the start of spring?",
    "Will the programmer have debugged the software before the release?",
    "Will they have relaxed after the meeting ends?",
    "Will we have discussed the project during the team meeting?",
    "Will the student have answered all the questions by the end of the class?",
    "Will the neighbors have moved into their new house by next month?",
    "Will the teacher have assigned all the homework before the holidays?",
    "Will the artist have painted a new landscape for the gallery exhibit?",
    "Will the cat have chased the mouse before it hides?",
    "Will the players have warmed up before the big game starts?",
    "Will the kids have swung on the swings before the park closes?",
    "Will you have painted the walls in the new house before moving in?",
    "Will the chef have prepared a special dessert for the dinner party?",
    "Will the librarian have stacked the books before the library opens?",
    "Will the bakers have decorated the cake for the wedding reception?",
    "Will the singer have practiced her new song before the performance?",
    "Will the parents have watched their kids play before heading home?",
    "Will the dog have dug enough holes in the garden by the afternoon?",
    "Will the actor have practiced his lines before the scene begins?",
    "Will you have explained the new rules to the players by the start of the game?",
    "Will the waiter have served all the guests before the reception ends?",
    "Will the kids have learned the new game before recess is over?",
    "Will the scientists have conducted all experiments before the conference?",
    "Will the volunteers have distributed all the flyers by the end of the event?",
    "Will the guard have opened the gates for the visitors by the morning?",
    "Will the travelers have boarded the plane before the announcement is made?",
    "Will we have completed our tasks before the deadline approaches?",
    "Will the chef have prepared all the dishes before the dinner guests arrive?",
    "Will the kids have memorized their lines before the school play?",
    "Will the organizer have planned the event schedule before the week ends?",
    "Will the engineer have designed the new system before the project deadline?",
    "Will the nurse have treated all patients before the next shift arrives?",
    "Will the programmer have written the final code before the review starts?",
    "Will the designer have created all the outfits before the fashion show?",
    "Will the team have celebrated their victory before the press conference?",
    "Will the teacher have graded all the exams before the semester ends?",
    "Will the students have submitted their projects by the time class starts?",
    "Will the tourists have explored all the exhibits before the museum closes?",
    "Will the host have cleaned the house before the party guests arrive?",
    "Will the coach have trained the players before the tournament begins?",
    "Will the gardener have watered all the plants by the end of the day?",
    "Will the staff have organized the files before the audit starts?",
    "Will the customer have placed their order before the store closes?",
    "Will the cat have taken a nap before chasing the dog?",
    "Will the team have brainstormed all ideas before the presentation begins?",
    "Will the actors have rehearsed their scenes before the director reviews them?",
    "Will the pianist have performed her piece before the concert ends?",
    "Will the neighbors have moved their belongings before the movers arrive?",
    "Will the scientist have tested the hypothesis before presenting the findings?",
    "Will the child have solved the puzzle before the timer runs out?",
    "Will the librarian have cataloged the books by the start of the session?",
    "Will the students have completed their assignments before the weekend?",
    "Will the players have scored enough points before halftime?",
    "Will the researchers have gathered all data before concluding the study?",
    "Will the nurse have administered the medications before the doctor arrives?",
    "Will the hikers have reached the summit before sunset?",
    "Will the boat have docked at the port before the storm hits?",
    "Will the chef have finalized the menu before the guests arrive?",
    "Will the writer have finished her book before the deadline?",
    "Will the engineer have built the prototype before the demo starts?",
    "Will the team have polished their presentation before the final meeting?",
    "Will the kids have finished their snacks before the movie begins?",
    "Will we have packed our bags before the taxi arrives?",
    "Will the flowers have bloomed fully before the photo shoot starts?",
    "Will the planner have prepared the itinerary before the tour starts?",
    "Will the singer have rehearsed her song before the audience arrives?",
    "Will the athletes have trained enough before the championship game?",
    "Will the teacher have reviewed the lessons before the final class?",
    "Will the students have completed the test before the bell rings?",
    "Will you have arranged the decorations before the guests arrive?",
    "Will the volunteers have set up the stalls before the festival begins?",
    "Will the chef have tested the new recipe before adding it to the menu?",
    "Will the artist have finalized her painting before the auction?",
    "Will the crew have fixed the broken equipment before the broadcast?",
    "Will the parents have packed their kids' lunches before school starts?",
    "Will the researcher have completed her analysis before the report is due?",

    };
    public HashSet<string> future_perfect_continuous_questions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
    "Will you have been reading that book for hours by the time we return?",
    "Will she have been watching the movie for three hours by the time it ends?",
    "Will they have been playing football for an hour by the time the rain starts?",
    "Will he have been working on his project for days by the deadline?",
    "Will we have been cleaning the house for hours before the guests arrive?",
    "Will the dog have been barking for a while before they come back?",
    "Will the kids have been playing in the park all afternoon by sunset?",
    "Will John have been fixing the car since the morning by the time he finishes?",
    "Will my parents have been organizing the party for days by the weekend?",
    "Will the teacher have been explaining the topic for hours by the end of the lesson?",
    "Will we have been helping them with their work all evening by the time it’s done?",
    "Will the cat have been sleeping on the couch since noon by dinner time?",
    "Will Sarah have been writing her essay for hours by the time it’s ready?",
    "Will the students have been studying for days by the time the exam starts?",
    "Will Alice have been practicing the piano for weeks by the concert?",
    "Will you have been washing the dishes for an hour before the guests arrive?",
    "Will Mike have been arranging the documents all day before the meeting?",
    "Will they have been traveling for hours by the time they reach the destination?",
    "Will Emma have been baking a cake since the morning by lunchtime?",
    "Will we have been solving puzzles together for hours by the evening?",
    "Will Tom have been painting the fence for days by the time he finishes?",
    "Will David have been teaching English for years by the time he retires?",
    "Will my cousins have been visiting the museum all day by closing time?",
    "Will the workers have been repairing the bridge for weeks by its reopening?",
    "Will James have been preparing dinner for an hour by the time we eat?",
    "Will the kids have been building a sandcastle for hours by the time the tide comes in?",
    "Will the train have been running late for a while by the time it arrives?",
    "Will the tourists have been taking pictures for hours by the end of the tour?",
    "Will Jack have been designing the poster all week by the time of the event?",
    "Will I have been helping you with your assignment for days by the deadline?",
    "Will the manager have been organizing the project for months by its launch?",
    "Will the nurses have been treating patients all day by the time their shift ends?",
    "Will the baby have been crying for hours by the time she falls asleep?",
    "Will we have been arranging the chairs for the event all morning by the time it starts?",
    "Will the gardener have been planting flowers for days by the time the garden is ready?",
    "Will the students have been discussing their project for hours by the presentation?",
    "Will the librarian have been sorting books all day by the time the library opens?",
    "Will he have been solving that difficult puzzle for hours by the competition's end?",
    "Will the musicians have been performing for an hour by the time the curtain falls?",
    "Will Lily have been sketching her masterpiece for days by the time her class evaluates it?",
    "Will the chefs have been preparing meals since dawn by the time the guests arrive?",
    "Will the sun have been setting for an hour by the time darkness falls?",
    "Will the carpenter have been building furniture for months by the exhibition?",
    "Will the kids have been riding their bikes in the park for hours by dinnertime?",
    "Will you have been watering the plants since morning by the afternoon?",
    "Will we have been exploring the forest for hours by the time we return?",
    "Will the teacher have been checking homework for hours by the end of the day?",
    "Will they have been feeding the animals for days by the time visitors arrive?",
    "Will the baby have been sleeping for hours by the time she wakes up?",
    "Will my neighbors have been inviting friends for weeks by the time of the party?",
    "Will Alice have been sewing her dress for hours by the wedding day?",
    "Will Emma have been designing the website for months by its launch date?",
    "Will the students have been revising their notes for days by the test day?",
    "Will Sarah have been explaining the instructions for hours by the task's start?",
    "Will the birds have been flying south for months by the time winter comes?",
    "Will he have been learning to play the guitar for years by the concert?",
    "Will I have been improving my skills at the workshop for weeks by the evaluation?",
    "Will the software have been updating for hours by the time it's complete?",
    "Will the doctor have been treating patients all day by the time the hospital closes?",
    "Will the organizers have been planning the event for months by the opening?",
    "Will you have been repairing the chair for hours by the time it's fixed?",
    "Will the team have been practicing for days by the time of the final match?",
    "Will Mike have been ironing his clothes for half an hour by the time he leaves?",
    "Will we have been planting trees for hours by the end of the morning?",
    "Will John have been painting portraits for weeks by the art gallery's grand opening?",
    "Will the children have been arranging toys for an hour by the time they're done?",
    "Will Tom have been collecting tickets at the station all day by the evening?",
    "Will Lily have been polishing the silverware for hours by the time the event begins?",
    "Will we have been dusting the furniture all morning by the time the guests arrive?",
    "Will the computer have been processing data for hours by the time the results are ready?",
    "Will the workers have been building the new office for months by the time it’s completed?",
    "Will the kids have been drawing pictures for hours by the time their class ends?",
    "Will Sarah have been rehearsing her lines for weeks by the time of the show?",
    "Will the pianist have been performing her piece for minutes by the time the audience applauds?",
    "Will they have been brainstorming ideas for days by the time the project starts?",
    "Will the family have been decorating the Christmas tree all day by the evening?",
    "Will the director have been discussing the agenda for hours by the start of the meeting?",
    "Will we have been organizing files for hours by the audit time?",
    "Will Emma have been analyzing the results for weeks by the presentation day?",
    "Will the manager have been holding meetings all week by Friday?",
    "Will the host have been welcoming guests for hours by the time dinner starts?",
    "Will they have been climbing the mountain all morning by the time they reach the top?",
    "Will we have been finishing our assignments for days by the submission date?",
    "Will the travelers have been packing for hours by the time the taxi arrives?",
    "Will the artist have been creating a sculpture for weeks by the exhibition?",


    };
    #endregion

    #region AFFIRMATIONS INITIALIZATION
    public HashSet<string> present_simple_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "She loves music.",
            "He enjoys playing video games.",
            "It rains often in the countryside.",
            "We study math skills every evening.",
            "They listen to podcasts during their commute.",
            "You bake cakes for special occasions.",
            "I ride bicycles in the park.",
            "John teaches English at the local school.",
            "Sarah reads her favorite book every night.",
            "David paints portraits of his friends.",
            "Emma writes novels in her free time.",
            "Tom swims in the pool during summer.",
            "Mike designs innovative business strategies.",
            "Lily sings beautifully during concerts.",
            "Alice fixes computers at the workshop.",
            "James buys groceries every Saturday.",
            "Jack plays basketball with his classmates.",
            "My parents travel to the mountains every year.",
            "The students discuss their homework before class.",
            "Her brother helps with the heavy boxes.",
            "His father builds wooden furniture.",
            "My friends watch movies on weekends.",
            "The kids enjoy playing in the park.",
            "The birds sing sweet melodies in the morning.",
            "The engineers design bridges for the city.",
            "The tourists visit the art gallery during their trip.",
            "My cousins bake cookies together during holidays.",
            "My classmates clean the classroom after school.",
            "My neighbors plant flowers in their garden.",
            "His cousin drives the car to work.",
            "Her sister studies in the library every afternoon.",
            "The dogs bark loudly when the mail arrives.",
            "His boss organizes meetings regularly.",
            "My grandparents prefer watching the news in the evening.",
            "The nurses assist patients with care.",
            "The cat sits near the window on sunny days.",
            "The baby sleeps peacefully in the crib.",
            "Who plays the piano beautifully?",
            "Coffee tastes amazing in the morning.",
            "Car races are exciting to watch.",
            "Music inspires creativity in people.",
            "Emails arrive at odd hours sometimes.",
            "Ice cream melts quickly on hot days.",
            "Movies entertain people of all ages.",
            "Homework helps improve learning.",
            "The office opens at 9 AM every day.",
            "Sushi is popular in Japan.",
            "Cakes are delicious when freshly baked.",
            "Pictures capture memorable moments.",
            "Glasses improve vision for many.",
            "Water quenches thirst on hot days.",
            "Bicycles are an eco-friendly mode of transport.",
            "Computers process information quickly.",
            "Windows let in natural light.",
            "News keeps us informed about the world.",
            "Bridges connect distant places.",
            "Medicine helps cure illnesses.",
            "Your cat chases mice playfully.",
            "The workers repair damaged roads.",
            "Her mother cooks delicious meals.",
            "His uncle tells interesting stories.",
            "Her boyfriend drives her to the airport.",
            "My teachers explain complex topics clearly.",
            "Her friends plan trips together.",
            "The guests enjoy their stay at the hotel.",
            "Their neighbors invite them for dinner.",
            "His desk has important documents on it.",
            "Her dog waits patiently for her return.",
            "Their room smells of fresh flowers.",
            "His house is near the lake.",
            "The train arrives on time every day.",
            "His bike needs some repair work.",
            "The teacher helps students solve problems.",
            "Their friends share jokes during lunch.",
            "The cats sleep on the couch during the day.",
            "The furniture looks elegant in the living room.",
            "The jokes make everyone laugh out loud.",
            "His scarf feels soft and warm.",
            "The hill offers a breathtaking view.",
            "His client requests urgent reports.",
            "The car stops at the red light.",
            "The silverware shines after polishing.",
            "The piano sounds beautiful in the music room.",
            "The couch provides comfort after a long day.",
            "Her book inspires young readers.",
            "His partner designs innovative projects.",
            "Her grandmother bakes delicious pies.",
            "Their project moves forward with teamwork.",
            "The package arrives earlier than expected.",
            "The new room smells of fresh paint.",
            "The beach attracts many tourists.",
            "Her dress looks elegant on her.",
            "His pencils break easily under pressure.",
            "The decorations improve the atmosphere.",
            "The lost items return to their owners.",
            "The heavy boxes require extra help.",
            "Their dance routine impresses the audience.",
            "The vase contains beautiful flowers.",
            "Her favorite song plays on the radio.",
            "Her website attracts many visitors.",
            "The soup tastes delicious.",
            "The trip creates lasting memories.",
            "The budget balances perfectly.",
            "Her future depends on her decisions.",
            "Secrets remain hidden for years.",
            "His parents visit him every weekend.",
            "Your grandparents tell wonderful stories.",
            "The team works hard to achieve success.",
            "The director watches the rehearsal carefully.",
            "Her siblings support her dreams.",
            "The art gallery features stunning paintings.",
            "The application receives approval quickly.",
            "His teacher explains the concepts clearly.",
            "The house needs regular maintenance.",
            "Their relatives call during the holidays.",
            "The doctor treats patients with compassion.",
            "The party brings everyone together.",
            "The museum houses ancient artifacts.",
            "The concert entertains the audience.",
            "The office remains quiet during lunch.",
            "The client appreciates the quick service.",
            "The workshop improves technical skills.",
            "Her novel receives positive reviews.",
            "The marathon challenges the runners.",
            "The rules govern fair play.",
            "The report details recent findings.",
            "The professor guides the students effectively.",
            "The database stores important information.",
            "The kitchen smells of freshly baked bread.",
            "The library lends books to students.",
            "The living room feels cozy and warm.",
            "The dishes pile up in the sink.",
            "Their house welcomes guests warmly.",
            "The chair breaks under heavy weight.",
            "Your passport allows international travel.",
            "Your room stays clean and organized.",
            "His workspace encourages productivity.",
            "Her pet waits by the door.",
            "Her flight departs on time.",
            "The software updates automatically.",
            "The surprise party amazes the guests.",
            "Her portfolio showcases her talent.",
            "The podcast attracts a global audience.",
            "The batteries power the remote control.",
            "The family shares unforgettable moments.",
            "Their wedding marks a joyful occasion.",
            "The community plans various events.",
            "The garage stores unused tools.",
            "Clients trust reliable services.",
            "The walls need a fresh coat of paint.",
            "His presentation impresses the managers.",
            "Her career goals motivate her daily.",
            "Dance classes improve flexibility and rhythm.",
            "Flowers brighten up the garden.",
            "Groceries stock the pantry.",
            "Puzzles challenge logical thinking.",
            "The pool reflects the clear blue sky.",
            "Artwork decorates the walls elegantly.",
            "English serves as a global language.",
            "The play entertains the audience.",
            "The lake mirrors the surrounding hills.",
            "Your language skills improve with practice.",
            "The countryside offers peace and tranquility.",
            "Business strategies guide company growth.",
            "Video games provide endless entertainment.",
            "A sandcastle stands tall on the beach.",
            "Dinner tastes better when shared.",
            "Documentaries educate and inspire viewers.",
            "The city hums with activity day and night.",
            "Plants grow faster in sunlight.",
            "Your friend calls to share exciting news.",
            "A new apartment provides more space.",
            "Recipes pass down through generations.",
            "Exercises strengthen the body.",
            "Clothes hang neatly in the closet.",
            "Basketball skills improve with practice.",
            "Mountains rise majestically in the distance.",
            "A job offers financial stability.",
            "Your siblings visit during the holidays.",
            "Math skills sharpen with practice.",
            "Portraits capture the essence of individuals.",
            "Notes help students prepare for exams.",
            "Sketches outline creative ideas.",
            "Tickets grant entry to exclusive events.",
            "A scarf protects against the cold.",
            "Their speech inspires the audience.",
            "Our house welcomes friends and family."

    };
    public HashSet<string> present_continuous_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> present_perfect_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> present_perfect_continuous_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };

    public HashSet<string> past_simple_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> past_continuous_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> past_perfect_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> past_perfect_continuous_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };

    public HashSet<string> future_simple_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> future_continuous_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> future_perfect_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> future_perfect_continuous_affirmations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    #endregion

    #region NEGATIONS INITIALIZATION
    public HashSet<string> present_simple_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> present_continuous_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> present_perfect_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> present_perfect_continuous_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };

    public HashSet<string> past_simple_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> past_continuous_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> past_perfect_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> past_perfect_continuous_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };

    public HashSet<string> future_simple_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> future_continuous_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> future_perfect_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    public HashSet<string> future_perfect_continuous_negations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { };
    #endregion

    public Dictionary<string, HashSet<string>> wordCategories = new Dictionary<string, HashSet<string>>()
    {
        { "wh-word", new HashSet<string> { "why", "when", "where", "how", "what", "which" } },
        { "auxiliary", new HashSet<string> { "does", "do", "is", "are" } },
        { "subject", new HashSet<string>
            {   "she", "he", "it", "we", "they", "you", "I", "John", "Sarah", "David", "Emma", "Tom", "Mike", "Lily", "Alice", "James", "Jack", "my parents",
            "the students", "her brother", "his father", "my friends", "the kids", "the birds", "the engineers", "the tourists", "my cousins", "my classmates",
            "my neighbors", "his cousin", "her sister", "the dogs", "his boss", "my grandparents", "the nurses", "the cat", "the baby", "who", "coffee", "car",
            "music", "emails", "ice cream", "movies", "homework", "office", "sushi", "cakes", "pictures", "glasses", "water", "bicycles", "computers", "windows",
            "news", "bridges", "medicine", "your cat", "the workers", "her mother", "his uncle", "her boyfriend", "my teachers", "her friends", "the guests",
            "their neighbors", "his desk", "her dog", "their room", "his house", "the train", "his bike", "the teacher", "their friends", "the cats", "the furniture",
            "the jokes", "his scarf", "the hill", "his client", "the car", "the silverware", "the piano", "the couch", "the manager", "the garden", "the meeting",
            "her book", "his partner", "her grandmother", "their project", "the package", "the new room", "the beach", "her dress", "his pencils", "the decorations",
            "the lost items", "the heavy boxes", "their dance routine", "the vase", "her favorite song", "her website", "the soup", "the trip", "the budget",
            "her future", "secrets", "his parents", "your grandparents", "the team", "the director", "her siblings", "the art gallery", "the application",
            "his teacher", "the house", "their relatives", "the doctor", "the party", "the museum", "the concert", "the office", "the client", "the workshop",
            "her novel", "the marathon", "the rules", "the report", "the professor", "the database", "the kitchen", "the library", "the living room", "the dishes",
            "their house", "the chair", "your passport", "your room", "his workspace", "her pet", "her flight", "the software", "the surprise party", "her portfolio",
            "the podcast", "the batteries", "the family", "their wedding", "the community", "the garage", "clients", "the walls", "his presentation", "her career goals",
            "dance classes", "flowers", "groceries", "puzzles", "the pool", "artwork", "English", "the play", "the lake", "your language skills", "the countryside",
            "business strategies", "video games", "a sandcastle", "dinner", "documentaries", "the city", "plants", "your friend", "a new apartment", "recipes",
            "exercises", "clothes", "basketball skills", "mountains", "a job", "your siblings", "math skills", "portraits", "notes", "sketches", "tickets", "a scarf",
            "their speech", "our house"

        } },
        { "verb", new HashSet<string>
            {  "drink", "visit", "drive", "enjoy", "rain", "arrive", "play", "listen", "work", "call",
                "write", "like", "walk", "cook", "cost", "watch", "travel", "sleep", "have", "clean",
                "buy", "sell", "exercise", "dance", "sing", "fix", "bake", "swim", "teach", "eat",
                "study", "read", "prefer", "sound", "help", "bark", "go", "ride", "repair", "send",
                "taste", "finish", "build", "wake", "is", "are", "am", "doing", "thinking", "coming",
                "raining", "staying", "shouting", "waiting", "discussing", "having", "running", "arguing",
                "painting", "traveling", "meeting", "talking", "shopping", "learning", "feeling", "crying",
                "sitting", "enjoying", "planning", "moving", "joining", "becoming", "designing", "searching",
                "washing", "speaking", "organizing", "starting", "checking", "preparing", "standing", "trying",
                "exploring", "feeding", "getting", "making", "smiling", "forgetting", "opening", "driving",
                "recording", "solving", "holding", "delivering", "heading", "celebrating", "parking", "leaving",
                "does", "do", "love", "complain", "start", "smell", "take", "paint", "give", "open", "order",
                "wear", "miss", "practice", "meet", "live", "understand", "agree", "find", "lose", "return",
                "accept", "explain", "recommend", "answer", "complete", "borrow", "check", "teach", "prepare",
                "was", "were", "helping", "behaving", "snowing", "performing", "decorating", "reviewing",
                "dusting", "climbing", "answering", "carrying", "planting", "arranging", "calculating", "will",
                "analyze", "attend", "improve", "look", "talk", "cry", "head", "iron", "sweep", "brush", "edit",
                "taste", "whisper", "relax", "dust", "laugh", "wipe", "sew", "dream", "knit", "polish",
                "calculate", "spend", "admire", "submit", "receive", "perform", "celebrate", "adopt", "book",
                "upload", "respect", "aim", "launch", "thought", "replace", "install", "grow", "compete",
                "remove", "volunteer", "focus", "fishing", "cycling", "arrange", "water", "rehearse", "fold",
                "tidy", "memorize", "hang", "cheer", "brainstorm", "adjust", "skip", "babysit", "discover"
        } },
        { "preposition", new HashSet<string> { "in", "on", "at", "to", "with", "for", "before", "after", "during", "as" } },
        { "averbs", new HashSet<string> { "always", "sometimes", "often", "rarely", "never", "usually", "hardly ever", "occasionally", "quickly", "quietly", "eagerly", "easily", "regularly", "slowly", "happily", "frequently", "seldom", "boldly", "carefully" } },
        { "time", new HashSet<string> { "morning", "weekends", "evening", "night", "winter", "Fridays" } },
        { "otherWords", new HashSet<string> {  } } // parole che stanno nelle frasi ma non qui dentro mannaggia zio
    };

    void Start()
    {
        Debug.LogWarning("Show a Panel in which you say that atm no all words are recognized!");
        // in base al primo dropdown fai gli update
        HandlePhraseType();
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, selectedTense));
    }
    public void UpdateSelectedTense()
    {
        checkButton.onClick.RemoveAllListeners();
        checkButton.onClick.AddListener(() => CheckUserInput(userInputField.text, tenseDropdown.options[tenseDropdown.value].text));
        UpdateQuestionRule();
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void CheckUserInput(string userInput, string tense)
    {
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                bool isAValidQuestion = MatchesBasedOnType(userInput);
                feedbackText.text = isAValidQuestion ? "Correct!" : "Incorrect structure Or some words not yet recognized Or did you miss the '?', Please Retry.";
                break;
            case "Affirmations":
                bool isAValidAffirmation = MatchesBasedOnType(userInput);
                feedbackText.text = isAValidAffirmation ? "Correct!" : "Incorrect structure Or some words not yet recognized Or did you miss the '.'? Please Retry.";
                break;
            case "Negations":
                bool isAValidNegations = MatchesBasedOnType(userInput);
                feedbackText.text = isAValidNegations ? "Correct!" : "Incorrect structure Or some words not yet recognized Or did you miss the '.'? Please Retry.";
                break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
    }
    public void UpdateQuestionRule()
    {
        // spostare in un panel
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Question_Rules(); break;
            case "Present Cont.": rule_dynamic_text.text = Return_PresentContinuous_Question_Rules(); break;
            case "Present Perfect": rule_dynamic_text.text = Return_Present_Perfect_Question_Rule(); break;
            case "Present Perfect Cont.": rule_dynamic_text.text = Return_Present_Perfect_Continuous_Question_Rule(); break;

            case "Past Simple": rule_dynamic_text.text = Return_Past_Simple_Question_Rules(); break;
            case "Past Cont.": rule_dynamic_text.text = Return_Past_Continuous_Question_Rule(); break;
            case "Past Perfect": rule_dynamic_text.text = Return_Past_Perfect_Question_Rule(); break;
            case "Past Perfect Cont.": rule_dynamic_text.text = Return_Past_Perfect_Continuous_Question_Rule(); break;

            case "Future Simple": rule_dynamic_text.text = Return_Future_Simple_Question_Rule(); break;
            case "Future Cont.": rule_dynamic_text.text = Return_Future_Continuous_Question_Rule(); break;
            case "Future Perfect": rule_dynamic_text.text = Return_Future_Perfect_Question_Rule(); break;
            case "Future Perfect Cont.": rule_dynamic_text.text = Return_Future_Perfect_Continuous_Question_Rule(); break;
            default: Debug.LogError("error on UpdateQuestionRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void UpdateAffirmationsRule()
    {
        // spostare in un panel
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Affirmation_Rules(); break;
            case "Present Cont.": rule_dynamic_text.text = Return_PresentContinuous_Affirmation_Rules(); break;
            case "Present Perfect": rule_dynamic_text.text = Return_PresentPerfect_Affirmation_Rules(); break;
            case "Present Perfect Cont.": rule_dynamic_text.text = Return_PresentPerfectContinuous_Affirmation_Rules(); break;

            case "Past Simple": rule_dynamic_text.text = Return_PastSimple_Affirmation_Rules(); break;
            case "Past Cont.": rule_dynamic_text.text = Return_PastContinuous_Affirmation_Rules(); break;
            case "Past Perfect": rule_dynamic_text.text = Return_PastPerfect_Affirmation_Rules(); break;
            case "Past Perfect Cont.": rule_dynamic_text.text = Return_PastPerfectContinuous_Affirmation_Rules(); break;

            case "Future Simple": rule_dynamic_text.text = Return_FutureSimple_Affirmation_Rules(); break;
            case "Future Cont.": rule_dynamic_text.text = Return_FutureContinuous_Affirmation_Rules(); break;
            case "Future Perfect": rule_dynamic_text.text = Return_FuturePerfect_Affirmation_Rules(); break;
            case "Future Perfect Cont.": rule_dynamic_text.text = Return_FuturePerfectContinuous_Affirmation_Rules(); break;
            default: Debug.LogError("error on UpdateQuestionRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void UpdateNegationRule()
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": rule_dynamic_text.text = Return_PresentSimple_Negations_Rules(); break;
            case "Present Cont.": rule_dynamic_text.text = Return_PresentContinuous_Negations_Rules(); break;
            case "Present Perfect": rule_dynamic_text.text = Return_Present_Perfect_Negations_Rule(); break;
            case "Present Perfect Cont.": rule_dynamic_text.text = Return_Present_Perfect_Continuous_Negations_Rule(); break;

            case "Past Simple": rule_dynamic_text.text = Return_Past_Simple_Negations_Rules(); break;
            case "Past Cont.": rule_dynamic_text.text = Return_Past_Continuous_Negations_Rule(); break;
            case "Past Perfect": rule_dynamic_text.text = Return_Past_Perfect_Negations_Rule(); break;
            case "Past Perfect Cont.": rule_dynamic_text.text = Return_Past_Perfect_Continuous_Negations_Rule(); break;

            case "Future Simple": rule_dynamic_text.text = Return_Future_Simple_Negations_Rule(); break;
            case "Future Cont.": rule_dynamic_text.text = Return_Future_Continuous_Negations_Rule(); break;
            case "Future Perfect": rule_dynamic_text.text = Return_Future_Perfect_Negations_Rule(); break;
            case "Future Perfect Cont.": rule_dynamic_text.text = Return_Future_Perfect_Continuous_Negations_Rule(); break;
            default: Debug.LogError("error on UpdateNegationRule"); break;
        }
        Debug.Log("Selected Tense: " + tenseDropdown.options[tenseDropdown.value].text);
    }
    public void HandlePhraseType()
    {
        switch (phraseTypeDropdown.options[phraseTypeDropdown.value].text)
        {
            case "Questions":
                UpdateQuestionRule(); break;
            case "Affirmations":
                UpdateAffirmationsRule(); break;
            case "Negations":
                UpdateNegationRule(); break;
            default: Debug.Log("error on HandlePhraseType"); break;
        }
        Debug.Log("Selected Phrase Type: " + phraseTypeDropdown.options[phraseTypeDropdown.value].text);
    }
    private bool MatchesBasedOnType(string input)
    {
        if ("Questions".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return ReturnQuestionsBasedOntense(input);
        }
        else if ("Affirmations".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return ReturnAffirmationsBasedOntense(input);
        }
        else if ("Negations".Equals(phraseTypeDropdown.options[phraseTypeDropdown.value].text))
        {
            return ReturnNegationsBasedOntense(input);
        }

        Debug.Log("The phrase is incorrect.");
        return false;
    }
    public void CloseRememberPanel()
    {
        rememberPanel.SetActive(false);
    }
    public bool ReturnQuestionsBasedOntense(string input)
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": return IsAValidSimpleQuestion(input, present_simple_questions);
            case "Present Cont.": return IsAValidSimpleQuestion(input, present_continuous_questions);
            case "Present Perfect": return IsAValidSimpleQuestion(input, present_perfect_questions);
            case "Present Perfect Cont.": return IsAValidSimpleQuestion(input, present_perfect_continuous_questions);

            case "Past Simple": return IsAValidSimpleQuestion(input, past_simple_questions);
            case "Past Perfect": return IsAValidSimpleQuestion(input, past_perfect_questions);
            case "Past Cont.": return IsAValidSimpleQuestion(input, past_continuous_questions);
            case "Past Perfect Cont.": return IsAValidSimpleQuestion(input, past_perfect_continuous_questions);

            case "Future Simple": return IsAValidSimpleQuestion(input, future_simple_questions);
            case "Future Cont.": return IsAValidSimpleQuestion(input, future_continuous_questions);
            case "Future Perfect": return IsAValidSimpleQuestion(input, future_perfect_questions);
            case "Future Perfect Cont.": return IsAValidSimpleQuestion(input, future_perfect_continuous_questions);
            default: Debug.Log("error on UpdateNegationRule"); return false;
        }
    }
    public bool ReturnAffirmationsBasedOntense(string input)
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": return IsAValidSimpleQuestion(input, present_simple_affirmations);
            case "Present Cont.": return IsAValidSimpleQuestion(input, present_continuous_affirmations);
            case "Present Perfect": return IsAValidSimpleQuestion(input, present_perfect_affirmations);
            case "Present Perfect Cont.": return IsAValidSimpleQuestion(input, present_perfect_continuous_affirmations);

            case "Past Simple": return IsAValidSimpleQuestion(input, past_simple_affirmations);
            case "Past Perfect": return IsAValidSimpleQuestion(input, past_perfect_affirmations);
            case "Past Cont.": return IsAValidSimpleQuestion(input, past_continuous_affirmations);
            case "Past Perfect Cont.": return IsAValidSimpleQuestion(input, past_perfect_continuous_affirmations);

            case "Future Simple": return IsAValidSimpleQuestion(input, future_simple_affirmations);
            case "Future Cont.": return IsAValidSimpleQuestion(input, future_continuous_affirmations);
            case "Future Perfect": return IsAValidSimpleQuestion(input, future_perfect_affirmations);
            case "Future Perfect Cont.": return IsAValidSimpleQuestion(input, future_perfect_continuous_affirmations);
            default: Debug.Log("error on UpdateNegationRule"); return false;
        }
    }
    public bool ReturnNegationsBasedOntense(string input)
    {
        switch (tenseDropdown.options[tenseDropdown.value].text)
        {
            case "Present Simple": return IsAValidSimpleQuestion(input, present_simple_negations);
            case "Present Cont.": return IsAValidSimpleQuestion(input, present_continuous_negations);
            case "Present Perfect": return IsAValidSimpleQuestion(input, present_perfect_negations);
            case "Present Perfect Cont.": return IsAValidSimpleQuestion(input, present_perfect_continuous_negations);

            case "Past Simple": return IsAValidSimpleQuestion(input, past_simple_negations);
            case "Past Perfect": return IsAValidSimpleQuestion(input, past_perfect_negations);
            case "Past Cont.": return IsAValidSimpleQuestion(input, past_continuous_negations);
            case "Past Perfect Cont.": return IsAValidSimpleQuestion(input, past_perfect_continuous_negations);

            case "Future Simple": return IsAValidSimpleQuestion(input, future_simple_negations);
            case "Future Cont.": return IsAValidSimpleQuestion(input, future_continuous_negations);
            case "Future Perfect": return IsAValidSimpleQuestion(input, future_perfect_negations);
            case "Future Perfect Cont.": return IsAValidSimpleQuestion(input, future_perfect_continuous_negations);
            default: Debug.Log("error on UpdateNegationRule"); return false;
        }
    }

    static bool IsAValidSimpleQuestion(string input, HashSet<string> possibleQuestions)
    {
        return possibleQuestions.Contains(input) ? true : false;
    }


    #region FILL QUESTIONS RULES
    // PRESENT TENSE
    private string Return_PresentSimple_Question_Rules()
    {
        return "1.(auxiliary) + (subject) + (frequency adverb) + (base verb) + (object) + (other adverbs)?" + "\nEx.Does she often visit her grandparents?\n\n" +
               "2.(wh- word/How) + (frequency adverb) + (auxiliary) + (subject) + (base verb) + (object) + (other adverbs)?" + "\nHow often do you visit your parents?";
    }
    private string Return_PresentContinuous_Question_Rules()
    {
        return "1.(Wh- word}/(How) + (auxiliary verb (am/are/is)} + (subject} + (frequency adverb) + (base verb + -ing) + (other adverbs)" + "\nEx:What are you doing?\n\n" +
               "2.How (auxiliary) + (subject) + (verb) + (complement)." + "\nEx:How is she working today?";
    }
    private string Return_Present_Perfect_Question_Rule()
    {
        return "1. (Wh- word/How) + (have/has) + (subject) + (past participle) + (object/complement)?" + "\nEx: What have you done today?\n\n" +
                   "2. (Have/Has) + (subject) + (past participle) + (object/complement)?" + "\nEx: Have you finished your homework?";
    }
    private string Return_Present_Perfect_Continuous_Question_Rule()
    {
        return "1. Have/Has + (subject) + (frequency/quantity adverb) + been + (base verb + -ing) + (complement) + (other adverbs)?" +
       "\nEx: Have you always been practicing your piano consistently in the living room recently?\n\n" +
       "2. (Wh- word/How) + (have/has) + (subject) + (frequency/quantity adverb) + been + (base verb + -ing) + (complement) + (other adverbs)?" +
       "\nEx: How long have they been working on this project?";    
    }

    //  PAST TENSE
    private string Return_Past_Simple_Question_Rules()
    {
        return "1.(Wh- word/How) + (did) + (subject) + (base verb) + (object/complement)?" + "\nEx:What did you do yesterday?\n\n" +
               "2.(Wh- word) + (auxiliary) + (subject) + (base verb) + (complement)?" + "\nEx:Why did he leave early?";
    }
    private string Return_Past_Continuous_Question_Rule()
    {
        return "1.(Wh- word/How) + (was/were} + {subject} + {base verb + -ing} + {object/complement}?" + "\nEx:What were you doing yesterday evening?\n\n" +
               "2.(auxiliary) + (subject) + (base verb + -ing) + (complement)" + "\nEx:Was he sleeping at that time?";
    }
    private string Return_Past_Perfect_Question_Rule()
    {
        return "1. (Wh- word/How) + (had) + (subject) + (optional adverb) + (past participle) + (object/complement)?" +
                   "\nEx: Had she already finished her homework before dinner?\n\n" +
                   "2. (Had) + (subject) + (optional adverb) + (past participle) + (object/complement)?" +
                   "\nEx: Had they completed the task before the manager arrived?";
    }
    private string Return_Past_Perfect_Continuous_Question_Rule()
    {
        return "1.(Wh- word/How) + (had) + (optional adverb) + (subject) + (been) + (verb-ing) + (object/complement)?" + "\nHad she been studying for hours before the exam?\n\n";
    }
    // FUTURE TENSE
    private string Return_Future_Simple_Question_Rule()
    {
        return "1.(Wh- word/How) + (will) + (subject) + (base verb) + (object/complement)?" + "\nWhat will you do tomorrow?\n\n" +
               "2.Will + (subject) + (base verb) + (complement)." + "\nWill she come to the meeting?";
    }
    private string Return_Future_Continuous_Question_Rule()
    {
        return "1. (Wh- word/How) + (will) + (subject) + (be) + (verb-ing) + (object/complement)?" +
                   "\nEx: What will you be doing tomorrow?\n\n";
    }
    private string Return_Future_Perfect_Question_Rule()
    {
        return "1. (Wh- word/How) + (will) + (subject) + (have) + (past participle) + (object/complement)?" +
          "\nEx: Will she have finished her work by tomorrow?\n\n";
    }
    private string Return_Future_Perfect_Continuous_Question_Rule()
    {
        return "1. (Wh- word/How) + (will) + (subject) + (have been) + (verb-ing) + (object/complement)?" +
           "\nEx: How long will you have been working on this project by the end of the month?\n\n";
    }
    #endregion
    #region FILL AFFIRMATION RULES
    private string Return_PresentSimple_Affirmation_Rules()
    {
        return "1.(subject) + (base verb, 3rd person singular adds 's') + (object) + (other adverbs)." + "\nEx.She loves her family.\n\n" +
               "2.(subject) + (frequency adverb) + (base verb) + (object) + (other adverbs)." + "\nEx.They always play football on weekends.";
    }

    private string Return_PresentContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (be verb: am/is/are) + (verb+ing) + (object) + (other adverbs)." + "\nEx.He is reading a book.\n\n" +
               "2.(subject) + (be verb: am/is/are) + (frequency adverb) + (verb+ing) + (object) + (other adverbs)." + "\nEx.She is always studying in the library.";
    }

    private string Return_PresentPerfect_Affirmation_Rules()
    {
        return "1.(subject) + (have/has) + (past participle) + (object) + (other adverbs)." + "\nEx.I have visited Paris.\n\n" +
               "2.(subject) + (frequency adverb) + (have/has) + (past participle) + (object) + (other adverbs)." + "\nEx.She has never eaten sushi.";
    }

    private string Return_PresentPerfectContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (have/has) + (been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They have been playing football.\n\n" +
               "2.(subject) + (frequency adverb) + (have/has) + (been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.He has always been working hard.";
    }
    //  PAST TENSE
    private string Return_PastSimple_Affirmation_Rules()
    {
        return "1.(subject) + (past tense verb) + (object) + (other adverbs)." + "\nEx.She visited her grandparents yesterday.\n\n" +
               "2.(subject) + (frequency adverb) + (past tense verb) + (object) + (other adverbs)." + "\nEx.They often played chess after dinner.";
    }

    private string Return_PastContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (was/were) + (verb+ing) + (object) + (other adverbs)." + "\nEx.He was reading a book all afternoon.\n\n" +
               "2.(subject) + (frequency adverb) + (was/were) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They were always working late.";
    }

    private string Return_PastPerfect_Affirmation_Rules()
    {
        return "1.(subject) + (had) + (past participle) + (object) + (other adverbs)." + "\nEx.She had already left when he arrived.\n\n" +
               "2.(subject) + (frequency adverb) + (had) + (past participle) + (object) + (other adverbs)." + "\nEx.They had never seen such a beautiful sunset.";
    }

    private string Return_PastPerfectContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (had been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They had been studying for hours before the exam.\n\n" +
               "2.(subject) + (frequency adverb) + (had been) + (verb+ing) + (object) + (other adverbs).";
    }
    // FUTURE TENSE
    private string Return_FutureSimple_Affirmation_Rules()
    {
        return "1.(subject) + (will) + (base verb) + (object) + (other adverbs)." + "\nEx.She will visit her grandparents tomorrow.\n\n" +
               "2.(subject) + (frequency adverb) + (will) + (base verb) + (object) + (other adverbs)." + "\nEx.They will always remember this moment.";
    }

    private string Return_FutureContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (will be) + (verb+ing) + (object) + (other adverbs)." + "\nEx.She will be studying at the library this evening.\n\n" +
               "2.(subject) + (frequency adverb) + (will be) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They will always be working hard.";
    }

    private string Return_FuturePerfect_Affirmation_Rules()
    {
        return "1.(subject) + (will have) + (past participle) + (object) + (other adverbs)." + "\nEx.She will have finished her homework by 8 PM.\n\n" +
               "2.(subject) + (frequency adverb) + (will have) + (past participle) + (object) + (other adverbs)." + "\nEx.They will always have completed their tasks on time.";
    }

    private string Return_FuturePerfectContinuous_Affirmation_Rules()
    {
        return "1.(subject) + (will have been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.They will have been working on the project for three months by then.\n\n" +
               "2.(subject) + (frequency adverb) + (will have been) + (verb+ing) + (object) + (other adverbs)." + "\nEx.She will always have been practicing her piano before the recital.";
    }
    #endregion
    #region FILL NEGATIONS RULES
    private string Return_PresentSimple_Negations_Rules()
    {
        return "1. (subject) + (auxiliary 'do/does' + 'not') + (base verb) + (object) + (other adverbs)." + "\nEx. She does not like ice cream.\n\n" +
               "2. (wh- word/How) + (auxiliary 'do/does' + 'not') + (subject) + (base verb) + (object) + (other adverbs)." + "\nEx. Why do they not play football?";
    }

    private string Return_PresentContinuous_Negations_Rules()
    {
        return "1. (subject) + (verb 'to be' + 'not') + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. She is not reading the book.\n\n" +
               "2. (wh- word/How) + (verb 'to be') + (subject) + (not) + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why is he not studying?";
    }

    private string Return_Present_Perfect_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'have/has' + 'not') + (past participle) + (object) + (other adverbs)." + "\nEx. I have not finished the report.\n\n" +
               "2. (wh- word/How) + (auxiliary 'have/has') + (subject) + (not) + (past participle) + (object) + (other adverbs)." + "\nEx. Why has she not called?";
    }

    private string Return_Present_Perfect_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'have/has' + 'not') + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. I have not been waiting for hours.\n\n" +
               "2. (wh- word/How) + (auxiliary 'have/has') + (subject) + (not) + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why have they not been studying?";
    }
    //  PAST TENSE
    private string Return_Past_Simple_Negations_Rules()
    {
        return "1. (subject) + (auxiliary 'did' + 'not') + (base verb) + (object) + (other adverbs)." + "\nEx. They did not go to the park.\n\n" +
               "2. (wh- word/How) + (auxiliary 'did') + (subject) + (not) + (base verb) + (object) + (other adverbs)." + "\nEx. Why did she not attend the meeting?";
    }

    private string Return_Past_Continuous_Negations_Rule()
    {
        return "1. (subject) + (verb 'to be' in past + 'not') + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. She was not reading the book.\n\n" +
               "2. (wh- word/How) + (verb 'to be' in past) + (subject) + (not) + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why were they not playing football?";
    }

    private string Return_Past_Perfect_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'had' + 'not') + (past participle) + (object) + (other adverbs)." + "\nEx. She had not visited the museum.\n\n" +
               "2. (wh- word/How) + (auxiliary 'had') + (subject) + (not) + (past participle) + (object) + (other adverbs)." + "\nEx. Why had he not finished his homework?";
    }

    private string Return_Past_Perfect_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'had' + 'not') + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. I had not been waiting for long.\n\n" +
               "2. (wh- word/How) + (auxiliary 'had') + (subject) + (not) + 'been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why had they not been studying?";
    }
    // FUTURE TENSE
    private string Return_Future_Simple_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + (base verb) + (object) + (other adverbs)." + "\nEx. She will not attend the meeting.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + (base verb) + (object) + (other adverbs)." + "\nEx. Why will you not join us?";
    }

    private string Return_Future_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + 'be' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. He will not be traveling tomorrow.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + 'be' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why will she not be working?";
    }

    private string Return_Future_Perfect_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + 'have' + (past participle) + (object) + (other adverbs)." + "\nEx. They will not have completed the project.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + 'have' + (past participle) + (object) + (other adverbs)." + "\nEx. Why will she not have finished the task?";
    }

    private string Return_Future_Perfect_Continuous_Negations_Rule()
    {
        return "1. (subject) + (auxiliary 'will' + 'not') + 'have been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. I will not have been waiting for an hour.\n\n" +
               "2. (wh- word/How) + (auxiliary 'will') + (subject) + (not) + 'have been' + (verb in -ing form) + (object) + (other adverbs)." + "\nEx. Why will they not have been studying?";
    }
    #endregion

}