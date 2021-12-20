import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import { Icon } from '@iconify/react';
import plusFill from '@iconify/icons-eva/plus-fill';
import { useState } from 'react';
import { Grid, TextField } from '@mui/material';

const axios = require('axios');

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 500,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4
};

export default function ProductModal() {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const [IngredienteNome, setIngredienteNome] = useState('');
  const [IngredienteQuantidade, setIngredienteQuantidade] = useState('');

  const handleSubmit = () => {
    axios.put('http://localhost:5000/api/Ingredientes', {
      IngredienteNome,
      IngredienteQuantidade
    });
  };

  return (
    <div>
      <Button variant="contained" startIcon={<Icon icon={plusFill} />} onClick={handleOpen}>
        Adicionar Ingrediente
      </Button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <TextField
                label="Nome do ingrediente:"
                value={IngredienteNome}
                onInput={(e) => setIngredienteNome(e.target.value)}
                style={{ marginLeft: 20 }}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                label="Quantidade do ingrediente:"
                value={IngredienteQuantidade}
                onInput={(e) => setIngredienteQuantidade(e.target.value)}
              />
            </Grid>
            <Grid item xs={5} />
            <Grid>
              <Button style={{ marginTop: 30 }} variant="contained" onClick={handleSubmit()}>
                Submeter
              </Button>
            </Grid>
          </Grid>
        </Box>
      </Modal>
    </div>
  );
}
