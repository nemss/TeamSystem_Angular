import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './../home/home.component';
import { NewsComponent } from '../news/news.component';
import { AboutComponent } from './../about/about.component';
import { ContactComponent } from './../contact/contact.component';
import { LoginComponent } from './../login/login.component';
import { RegisterComponent } from './../register/register.component';
import { ArticleDetailsComponent } from './../news/details/article.details.component';
import { EditArticleComponent } from '../news/edit/edit.article.component';
import { CreateArticleComponent } from '../news/create/create.article.component';
import { PlayersComponent } from '../players/players.component';
import { PlayerDetailsComponent } from '../players/details/player.details.component';
import { EditPlayerComponent } from '../players/edit/player.edit.component';
import { CreatePlayerComponent } from '../players/create/player.create.component';
import { TeamsComponent } from '../teams/teams.component';
import { CreateTeamComponent } from '../teams/create/team.create.component';
import { TeamDetailsComponent } from '../teams/details/team.details.components';
import { MatchesComponent } from '../matches/matches.component';
import { EditTeamComponent } from '../teams/edit/team.edit.component';
import { CreateMatchComponent } from '../matches/create/match.create.component';


const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'matches', component: MatchesComponent },
  { path: 'match/:id', component: ArticleDetailsComponent },
  { path: 'match', component: CreateMatchComponent },
  { path: 'match/edit/:id', component: EditArticleComponent },

  { path: 'news', component: NewsComponent },
  { path: 'article/:id', component: ArticleDetailsComponent },
  { path: 'article', component: CreateArticleComponent },
  { path: 'article/edit/:id', component: EditArticleComponent },

  { path: 'players', component: PlayersComponent },
  { path: 'player/:id', component: PlayerDetailsComponent },
  { path: 'player', component: CreatePlayerComponent },
  { path: 'player/edit/:id', component: EditPlayerComponent },

  { path: 'teams', component: TeamsComponent },
  { path: 'team/:id', component: TeamDetailsComponent },
  { path: 'team', component: CreateTeamComponent },
  { path: 'team/edit/:id', component: EditTeamComponent },

  { path: 'contact', component: ContactComponent },
  { path: 'about', component: AboutComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }