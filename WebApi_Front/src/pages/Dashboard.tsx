import { Box, Container } from '@mui/material';

export default function Dashboard() {
  return (
    <Box sx={{ display: 'flex', marginTop: '100px' }}>
      <Container fixed>
        <h1>DASHHHHBOARDDDDDDDDDDDDDDDDD</h1>
        <p>
          On sait depuis longtemps que travailler avec du texte lisible et
          contenant du sens est source de distractions, et empêche de se
          concentrer sur la mise en page elle-même. L'avantage du Lorem Ipsum
          sur un texte générique comme 'Du texte. Du texte. Du texte.' est qu'il
          possède une distribution de lettres plus ou moins normale, et en tout
          cas comparable avec celle du français standard. De nombreuses suites
          logicielles de mise en page ou éditeurs de sites Web ont fait du Lorem
          Ipsum leur faux texte par défaut, et une recherche pour 'Lorem Ipsum'
          vous conduira vers de nombreux sites qui n'en sont encore qu'à leur
          phase de construction. Plusieurs versions sont apparues avec le temps,
          parfois par accident, souvent intentionnellement (histoire d'y
          rajouter de petits clins d'oeil, voire des phrases embarassantes).
        </p>
      </Container>
    </Box>
  );
}
