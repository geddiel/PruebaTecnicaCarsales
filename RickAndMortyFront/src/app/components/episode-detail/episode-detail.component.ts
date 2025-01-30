import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EpisodeService } from '../../services/episode.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-episode-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './episode-detail.component.html',
  styleUrls: ['./episode-detail.component.css']
})
export class EpisodeDetailComponent implements OnInit {
  episode: any;
  characters: any[] = [];

  constructor(private route: ActivatedRoute, private router: Router, public episodeService: EpisodeService) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.episodeService.getEpisodeDetail(parseInt(id));
    }
  }


  goBack(): void {
    this.router.navigate(['/']);
  }
}
