import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app.routes';
import { HttpModule } from '@angular/http';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';


import { AppComponent } from './app.component';
import { NavbarComponent } from '../navbar/navbar.component';
import { HomeComponent } from './../home/home.component';
import { ContactComponent } from '../contact/contact.component';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from './../register/register.component';
import { NewsComponent } from '../news/news.component';
import { AboutComponent } from './../about/about.component';
import { ArticleDetailsComponent } from './../news/details/article.details.component';
import { EditArticleComponent } from '../news/edit/edit.article.component';
import { CreateArticleComponent } from '../news/create/create.article.component';
import { PlayersComponent } from '../players/players.component';
import { PlayerDetailsComponent } from '../players/details/player.details.component';
import { QuestionableBooleanPipe } from '../../pipes/boolean.pipe';
import { EditPlayerComponent } from '../players/edit/player.edit.component';
import { CreatePlayerComponent } from '../players/create/player.create.component';
import { TeamsComponent } from '../teams/teams.component';
import { CreateTeamComponent } from '../teams/create/team.create.component';
import { TeamDetailsComponent } from '../teams/details/team.details.components';
import { MatchesComponent } from '../matches/matches.component';
import { EditTeamComponent } from '../teams/edit/team.edit.component';
import { CreateMatchComponent } from '../matches/create/match.create.component';



@NgModule({
  declarations: [
    AppComponent,
    QuestionableBooleanPipe,
    NavbarComponent,
    HomeComponent,
    NewsComponent,
    ArticleDetailsComponent,
    CreateArticleComponent,
    EditArticleComponent,
    PlayersComponent,
    PlayerDetailsComponent,
    EditPlayerComponent,
    CreatePlayerComponent,
    TeamsComponent,
    CreateTeamComponent,
    TeamDetailsComponent,
    EditTeamComponent,
    MatchesComponent,
    CreateMatchComponent,
    ContactComponent,
    AboutComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [{provide: LocationStrategy, useClass: HashLocationStrategy}],
  bootstrap: [AppComponent]
})
export class AppModule { }
